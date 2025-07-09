using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenGameManager : MonoBehaviour
{
    [SerializeField] GameObject panel;


    public void startGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void exitGame()
    {
        Application.Quit();
    }

    public void showPanel()
    {
        panel.SetActive(true);
    }   
    public void hidePanel()
    {
        panel.SetActive(false);
    }
}
