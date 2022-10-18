using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class UIStartGame : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }   
}