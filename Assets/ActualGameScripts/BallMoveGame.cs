using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallMoveGame : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private AudioSource a;

    private bool screenShaking = false;
    public float shakeDuration = 0.5f;
    public float shakeStrength = 0.3f;
    private Vector3 mainCamStartingPos;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        mainCamStartingPos = Camera.main.transform.position;
    }

    public void StartBall()
    {
        this.GetComponent<Rigidbody2D>().velocity = speed * new Vector2(1, 1).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        a.Play();
        Camera.main.DOShakePosition(shakeDuration, shakeStrength);
        StartCoroutine(ScreenShake());
    }

    private IEnumerator ScreenShake()
    {
        yield return new WaitForSeconds(shakeDuration);
        Camera.main.transform.position = mainCamStartingPos;
        screenShaking = false;
    }
}
