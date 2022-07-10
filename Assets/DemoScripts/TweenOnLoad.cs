using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenOnLoad : MonoBehaviour
{
    public int whichTween = 0;
    private float cycleLength = 2f;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ai;

    public void TweenSet(int val)
    {
        whichTween = val;
    }

    public float TweenIt()
    {
        switch (whichTween)
        {
            case 1:
                Linear();
                break;
            case 2:
                Bouncy();
                break;
            case 3:
                LessBouncy();
                break;
            case 4:
                Jump();
                break;
            default:
                break;
        }
        return cycleLength;
    }

    private void Linear()
    {
        cycleLength = 2f;
        ball.transform.localPosition = new Vector2(0, 0.318f);
        player.transform.localPosition = new Vector2(-0.479f, 0.318f);
        ai.transform.localPosition = new Vector2(0.479f, 0.318f);
        ball.transform.DOLocalMove(new Vector2(ball.transform.localPosition.x, 0), cycleLength);
        player.transform.DOLocalMove(new Vector2(player.transform.localPosition.x, 0), cycleLength);
        ai.transform.DOLocalMove(new Vector2(ai.transform.localPosition.x, 0), cycleLength);
    }

    private void Bouncy()
    {
        cycleLength = 3f;
        ball.transform.DOShakePosition(cycleLength, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        player.transform.DOShakePosition(cycleLength, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        ai.transform.DOShakePosition(cycleLength, strength: new Vector3(0, 2, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
    }

    private void LessBouncy()
    {
        cycleLength = 3f;
        ball.transform.DOShakePosition(cycleLength, strength: new Vector3(0, 0.2f, 0), vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
        player.transform.DOShakePosition(cycleLength, strength: new Vector3(0, 0.2f, 0), vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
        ai.transform.DOShakePosition(cycleLength, strength: new Vector3(0, 0.2f, 0), vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
    }

    private void Jump()
    {
        cycleLength = 1.5f;
        Vector3 aiStartingPos = ai.transform.localPosition;
        Vector3 playerStartingPos = player.transform.localPosition;
        player.transform.position = aiStartingPos;
        ai.transform.position = playerStartingPos;
        player.transform.DOLocalJump(playerStartingPos, 0.2f, 3, cycleLength, snapping: false);
        ai.transform.DOLocalJump(aiStartingPos, -0.2f, 3, cycleLength, snapping: false);
        ball.transform.DOLocalJump(ball.transform.localPosition, 0.1f, 3, cycleLength, snapping: false);
    }

}
