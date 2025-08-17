using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public int playerScore1, playerScore2;
    public ScoreText scoreTextLeft, scoreTextRight;

    public void AddScore(int id)
    {
        if (id == 1)
        {
            playerScore1++;
        }
        else if (id == 2)
        {
            playerScore2++;
        }

        UpdateScores();
    }   

    private void UpdateScores()
    {
        scoreTextLeft.SetScore(playerScore1);
        scoreTextRight.SetScore(playerScore2);
    }
}
