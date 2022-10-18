using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(OnPause);
        _resumeButton.onClick.AddListener(ResumePlay);
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);
        _menu.gameObject.SetActive(false);
    }

    private void OnPause()
    {
        Time.timeScale = 0;
        _menu.gameObject.SetActive(true);
    }

    private void ResumePlay()
    {
        Time.timeScale = 1;
        _menu.gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
