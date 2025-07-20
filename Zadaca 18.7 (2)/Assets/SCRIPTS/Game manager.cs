using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerHP = 5;
    public int score = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;  
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
        if (highscoreText != null)
            highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        if (playerHP <= 0)
        {
            gameOverPanel.SetActive(true);

            int savedHighscore = PlayerPrefs.GetInt("Highscore", 0);
            if (score > savedHighscore)
            {
                PlayerPrefs.SetInt("Highscore", score);
                PlayerPrefs.Save();

                if (highscoreText != null)
                    highscoreText.text = "Highscore: " + score;
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
