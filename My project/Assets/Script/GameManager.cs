using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    bool gameEnd;

    void Awake()
    {
        Instance = this;

        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void Victory()
    {
        if (gameEnd)
            return;

        gameEnd = true;

        victoryPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (gameEnd)
            return;

        gameEnd = true;

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
