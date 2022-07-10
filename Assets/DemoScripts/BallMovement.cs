using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.ParticleSystemJobs;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool screenShaking = false;
    private bool canShake = false;
    private float shakeDuration;
    private float shakeStrength;
    private Vector3 mainCamStartingPos;

    private bool canParticle = false;
    private ParticleSystem ps;

    private bool canTrail = false;
    private TrailRenderer trail;

    private bool canSFX = false;
    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        //cam shake
        shakeDuration = 0.5f;
        shakeStrength = 0.3f;
        mainCamStartingPos = Camera.main.transform.position;

        //particle
        ps = GetComponentInChildren<ParticleSystem>();

        //trail
        trail = GetComponent<TrailRenderer>();

        //sfx
        sfx = GetComponent<AudioSource>();

    }

    public void BallMove()
    {
        this.GetComponent<Rigidbody2D>().velocity = speed * new Vector2(1, 1).normalized;
    }

    public void BallStop()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(canSFX)
        {
            sfx.Play();
        }

        if(!screenShaking && canShake)
        {
            Camera.main.DOShakePosition(shakeDuration, shakeStrength);
            StartCoroutine(ScreenShake());
        }

        if(canParticle)
        {
            ps.Emit(10);
        }
    }

    private IEnumerator ScreenShake()
    {
        yield return new WaitForSeconds(shakeDuration);
        Camera.main.transform.position = mainCamStartingPos;
        screenShaking = false;
    }

    public void ToggleCanShake()
    {
        canShake = !canShake;
    }

    public void ToggleCanParticle()
    {
        canParticle = !canParticle;
    }

    public void ToggleCanTrail()
    {
        canTrail = !canTrail;

        if(canTrail)
        {
            trail.enabled = true;
        }
        else
        {
            trail.enabled = false;
        }
    }

    public void ToggleCanSFX()
    {
        canSFX = !canSFX;
    }

}