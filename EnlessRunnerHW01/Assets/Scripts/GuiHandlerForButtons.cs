using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiHandlerForButtons : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void resumeGame()
    {
        gameManager.resumeGame();
    }
    public void retryGame()
    {

    }
    public void exitToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }
    public void pauseGame()
    {

    }
}
