using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoonionsTween : MonoBehaviour
{
    [SerializeField] private SceneManage sm;
    [SerializeField] private Transform backend;
    [SerializeField] private Transform frontend;
    private RectTransform rocket;
    private bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        rocket = GetComponent<RectTransform>();
    }

    public void TweenAndStart()
    {
        StartCoroutine(TweenAndStartTimer());
    }

    public IEnumerator TweenAndStartTimer()
    {
        if(!started)
        {
            started = true;
            float cycleLength = 1.5f;
            rocket.DORotate(new Vector3(0, 0, -22), cycleLength, RotateMode.Fast);
            yield return new WaitForSeconds(cycleLength);

            cycleLength = 1.5f;
            rocket.DOMove(backend.position, cycleLength);
            yield return new WaitForSeconds(cycleLength);

            cycleLength = 2f;
            rocket.DORotate(new Vector3(0, 0, 157), cycleLength, RotateMode.Fast);
            yield return new WaitForSeconds(cycleLength);

            cycleLength = 5f;
            rocket.DOMove(frontend.position, cycleLength);
            yield return new WaitForSeconds(cycleLength);

            sm.LaunchStory();
        }
    }
}
