using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManagerGameSolo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ai;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject topwall;
    [SerializeField] private GameObject bottomwall;
    private float cycleLength = 1.5f;

    private void Start()
    {
        LinearTween();
    }

    public void LinearTween()
    {
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
    }

    private IEnumerator StartBall(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ball.GetComponent<BallMoveGame>().StartBall();
    }
}
