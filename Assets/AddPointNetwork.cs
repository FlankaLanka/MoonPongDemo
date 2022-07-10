using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class AddPointNetwork : NetworkBehaviour
{
    public Text pointsText;
    public Text pointsText2;

    [SyncVar]//[SyncVar(hook = nameof(OnP1PointsChanged))]
    int points;
    [SyncVar(hook = nameof(OnP2PointsChanged))]
    int points2;

    public void add()
    {
        Debug.Log(points);
        Debug.Log(points2);
            points++;

            points2++;
        
    }

    private void Update()
    {
        pointsText.text = points.ToString();
    }

    private void OnP1PointsChanged(int oldCount, int newCount)
    {
        pointsText.text = points.ToString();
    }

    private void OnP2PointsChanged(int oldCount, int newCount)
    {
        pointsText2.text = points2.ToString();
    }
}
