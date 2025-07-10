using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Drag and drop connection for Hierarchy
    public GameObject pauseMenu;
    public TMP_Text finalScore;
    private PlayerScore playerScore;
    public GameObject retryButton;
    public GameObject resumeButton;
    public int gameValMult;
    public float gameValDelay;
    private float time;
    public bool isPaused;

    void Start()
    {
        playerScore = gameObject.GetComponent<PlayerScore>();
        isPaused = false;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= gameValDelay)
        {
            updateScore();
            time = 0f;
        }
        pauseButtonPress();
    }
    public void pauseButtonPress()
    {
        //press E to pause the game
        if (Input.GetKeyDown(KeyCode.E) && !isPaused)
        {
            showPauseMenu();
            pauseGame();
        }
    }
    public void pauseGame()
    {
        retryButton.SetActive(false);
        resumeButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        hidePauseMenu();
    }

    public void showPauseMenu()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void hidePauseMenu()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        retryButton.SetActive(true);
        resumeButton.SetActive(false);
        playerScore.newHighScore();
        showPauseMenu();
        //showScore();
        
    }
    public void exitToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }
    public void retryGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1;
    }

    //public void showScore()
    //{
    //    if (playerScore.getScore() > PlayerPrefs.GetInt("Highscore"))
    //    {
    //        PlayerPrefs.SetInt("Highscore", playerScore.getScore());
    //        //Debug.Log("New highscore");
    //    }
    //    finalScore.text = "Final Score: " + playerScore.getScore().ToString();
    //}
    public void updateScore()
    {
        playerScore.setPlayerScore(gameValMult);
    }
}
