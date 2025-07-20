using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highscoreText;

    void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
}