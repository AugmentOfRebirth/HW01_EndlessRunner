using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //attached to game manager
    //drag connection for guiScore
    //when we kill an enemy we will call this script to increment/set the score.
    int playerScore;
    public TMP_Text guiScore;
    void Start()
    {
        playerScore = 0;
        //guiScore.text = "test";
    }

    public int getScore()
    {
        return playerScore;
    }

    public void setPlayerScore(int val)
    {
        playerScore += val;
        setGUIPlayerScore();
    }

    public void setGUIPlayerScore()
    {
        guiScore.text = "Score: ";
        guiScore.text += playerScore.ToString();
    }

    public void newHighScore()
    {
        
        int temp = getScore();

        int[] scores = new int[5];
        scores[0] = PlayerPrefs.GetInt("HighScore1", 0);
        scores[1] = PlayerPrefs.GetInt("HighScore2", 0);
        scores[2] = PlayerPrefs.GetInt("HighScore3", 0);
        scores[3] = PlayerPrefs.GetInt("HighScore4", 0);
        scores[4] = PlayerPrefs.GetInt("HighScore5", 0);

        for (int i = 0; i < scores.Length; i++)
        {
            if (temp > scores[i])
            {
                for (int ii = scores.Length - 1; ii > i; ii--)
                {
                    scores[ii] = scores[ii - 1];
                }

                scores[i] = temp;
                break;
            }
        }

        for (int i = 0; i < scores.Length; i++)
        {
            PlayerPrefs.SetInt("HighScore" + (i + 1), scores[i]);
        }

        PlayerPrefs.Save();

    }
    public void powerupScore(int points)
    {
        playerScore += points;
        setGUIPlayerScore();
    }


}
