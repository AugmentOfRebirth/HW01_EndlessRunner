using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Drag and drop connection for Hierarchy
    public GameObject pauseMenu;
    public TMP_Text finalScore;
    //private PlayerScore playerScore;

    private void Start()
    {
        //playerScore = gameObject.GetComponent<PlayerScore>();
    }
    private void Update()
    {
        pauseButtonPress();
    }
    public void pauseButtonPress()
    {
        //press E to pause the game
        if (Input.GetKeyDown(KeyCode.E))
        {
            showPauseMenu();
            pauseGame();
        }
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        hidePauseMenu();
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void hidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        showPauseMenu();
        //showScore();
    }

    //public void showScore()
    //{
    //    if (playerScore.getScore() > PlayerPrefs.GetInt("Highscore"))
    //    {
    //        PlayerPrefs.SetInt("Highscore", playerScore.getScore());
    //        Debug.Log("New highscore");
    //    }
    //    finalScore.text = "Final Score: " + playerScore.getScore().ToString();
    //}
}
