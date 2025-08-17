using UnityEngine;
using System.Collections;
using System.Collections.Generic;   

using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetScore(int score)
    {
        text.text = score.ToString();
    }
}
