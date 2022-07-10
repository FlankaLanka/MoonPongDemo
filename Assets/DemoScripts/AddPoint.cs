using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoint : MonoBehaviour
{
    public Text pointsText;

    public void add()
    {
        int score;
        int.TryParse(pointsText.text, out score);
        score += 1;
        pointsText.text = score.ToString();
    }
}
