using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private int _bonusCount;

        [SerializeField] private Unit _player;
        [SerializeField] private ObjectView[] _bonusView;
        [SerializeField] private Bonus[] _bonusObj;
        [SerializeField] private Text _pointsLabel;
        [SerializeField] private Text _healthLabel;
        [SerializeField] private Text _gameOverLabel;
        [SerializeField] private Text _endGameLabel;
        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _endGameMenu;
        [SerializeField] private Button _restartButtonLose;
        [SerializeField] private Button _restartButtonEnd;
        [SerializeField] private Button _exitButtonEnd;

        private InputController _inputController;
        private CameraController _cameraController;
        private ListExecuteObject _executeObject;
        private UIDisplayBonus _displayBonus;
        private UIDisplayHealth _displayHealth;
        private UIDisplayGameOver _displayGameOver;
        private UIDisplayEndGame _displayEndGame;
        private Player _health;

        private void Awake()
        {
            Time.timeScale = 1f;

            _health = gameObject.AddComponent<Player>();
            _health.Health = 100;

            _bonusObj = new Bonus[_bonusView.Length];

            for (int i = 0; i < _bonusView.Length; i++)
            {
                if (_bonusView[i].type == Type.good)
                {
                    _bonusObj[i] = new GoodBonus(_bonusView[i]);
                }
                else if (_bonusView[i].type == Type.bad)
                {
                    _bonusObj[i] = new BadBonus(_bonusView[i]);
                }
            }

            _inputController = new InputController(_player);
            _cameraController = new CameraController(_player._transform, Camera.main.transform); 
            _executeObject = new ListExecuteObject(_bonusObj);
            _displayBonus = new UIDisplayBonus(_pointsLabel);
            _displayHealth = new UIDisplayHealth(_healthLabel); 
            _displayGameOver = new UIDisplayGameOver(_gameOverLabel);
            _displayEndGame = new UIDisplayEndGame(_endGameLabel);

            _executeObject.AddExecuteObject(_inputController);
            _executeObject.AddExecuteObject(_cameraController);

            _gameOverMenu.gameObject.SetActive(false);
            _endGameMenu.gameObject.SetActive(false);
            _restartButtonLose.onClick.AddListener(RestartGame);
            _restartButtonEnd.onClick.AddListener(RestartGame);
            _exitButtonEnd.onClick.AddListener(ExitGame);
            _displayBonus.DisplayBonus(_bonusCount);
            _displayHealth.DisplayHealth(_health.Health);

            foreach (var item in _bonusObj)
            {
                if (item is GoodBonus goodBonus)
                    goodBonus.AddPoint += AddPoint;

                if (item is BadBonus badBonus)
                    badBonus.OnDamage += Damage;   
            }
        }

        private void AddPoint(int value)
        {
            _bonusCount += value;
            _displayBonus.DisplayBonus(_bonusCount);
        }

        private void Damage(int health)
        {
            _health.Health -= health;
            _displayHealth.DisplayHealth(_health.Health);
        }

        private void GameOver()
        {
            _gameOverMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        private void EndGame()
        {
            _endGameMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void Update()
        {
            if (_health.Health == 0)
            {
                _displayGameOver.GameOver();
                GameOver();
            }

            if (_bonusCount == 9)
            {
                _displayEndGame.EndGame();
                EndGame();
            }

            for (int i = 0; i < _executeObject.Lenght; i++)
            {
                if (_executeObject[i] == null)
                {
                    continue;
                }
                _executeObject[i].Update();
            }           
        }
    }
}