using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;
    public int missCount;
    public int maxMiss = 5;
    public TMP_Text scoreText;
    public TMP_Text lifeText;
    public GameObject gameOverPanel;
    bool gameOver = false;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false);
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }
    public void MeteorMiss()
    {
        missCount++;
        UpdateUI();
        if (missCount >= maxMiss)
        {
            GameOver();
        }
    }
    void UpdateUI()
    {
        scoreText.text = "Score : " + score;
        lifeText.text = "Miss : " + missCount + "/" + maxMiss;
    }
    void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
