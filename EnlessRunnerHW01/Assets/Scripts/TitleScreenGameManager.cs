using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenGameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
