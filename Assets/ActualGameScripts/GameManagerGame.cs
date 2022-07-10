using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mirror;

public class GameManagerGame : NetworkBehaviour
{
    private GameObject[] players;
    private GameObject player; //p1
    private GameObject ball;
    private GameObject ai; //p2
    [SerializeField] private GameObject topwall;
    [SerializeField] private GameObject bottomwall;
    private float cycleLength = 1.5f;
    private bool started = false;

    [SerializeField]
    private MyNetworkManager net;

    [ClientRpc]
    public void LinearTween()
    {
        if (!started)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
            if (isServer)
            {
                player = GameObject.Find("Player1");
                ai = GameObject.Find("Player2");
            }
            else
            {
                players = GameObject.FindGameObjectsWithTag("Player");
                if (players[0].GetComponent<NetworkIdentity>().netId > players[1].GetComponent<NetworkIdentity>().netId)
                {
                    player = players[1];
                    ai = players[0];
                }
                else
                {
                    player = players[0];
                    ai = players[1];
                }
            }


            cycleLength = 2f;
            ball.transform.position = new Vector2(0, 2.1f);
            player.transform.position = new Vector2(-4.6f, 2.1f);
            ai.transform.position = new Vector2(4.6f, 2.1f);
            ball.transform.DOMove(new Vector2(ball.transform.localPosition.x, 0), cycleLength);
            player.transform.DOMove(new Vector2(player.transform.localPosition.x, 0), cycleLength);
            ai.transform.DOMove(new Vector2(ai.transform.localPosition.x, 0), cycleLength);
            topwall.transform.DOLocalMove(new Vector2(0, topwall.transform.localPosition.y), cycleLength);
            bottomwall.transform.DOLocalMove(new Vector2(0, bottomwall.transform.localPosition.y), cycleLength);
            StartCoroutine(StartBall(cycleLength + 0.5f));
            started = true;
        }
    }

    private IEnumerator StartBall(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ball.GetComponent<BallMoveGame>().StartBall();
        if(isClientOnly)
        {
            //player.transform.position = new Vector3(4.6f, 0, 0);
        }
    }
}
