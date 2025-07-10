using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenGameManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public TextMeshProUGUI[] highScores;
    public static int hs1;
    public static int hs2;
    public static int hs3;
    public static int hs4;
    public static int hs5;

    void Start()
    {
        hs1 = PlayerPrefs.GetInt("HighScore1", 0);
        hs2 = PlayerPrefs.GetInt("HighScore2", 0);
        hs3 = PlayerPrefs.GetInt("HighScore3", 0);
        hs4 = PlayerPrefs.GetInt("HighScore4", 0);
        hs5 = PlayerPrefs.GetInt("HighScore5", 0);
    }
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
        highScores[0].text = hs1.ToString();
        highScores[1].text = hs2.ToString();
        highScores[2].text = hs3.ToString();
        highScores[3].text = hs4.ToString();
        highScores[4].text = hs5.ToString();
        panel.SetActive(true);
    }   
    public void hidePanel()
    {
        panel.SetActive(false);
    }
    
}
