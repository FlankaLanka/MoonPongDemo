using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    private AudioSource bgm;
    private bool canBGM = false;

    private TweenOnLoad tweener;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject AI;
    private Vector2[] StartPositions;
    [SerializeField] private GameObject StartScreen;
    private Vector3 mainCamStartingPos;
    public bool gameStarted = false;

    [SerializeField] private GameObject StoryScreen;
    public bool canStory = false;


    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<TweenOnLoad>();

        bgm = GetComponent<AudioSource>();
        player.GetComponent<PlayMove>().enabled = false;
        ball.GetComponent<BallMovement>().enabled = false;
        AI.GetComponent<AIMovement>().enabled = false;
        StartPositions = new Vector2[3];
        StartPositions[0] = player.transform.position;
        StartPositions[1] = ball.transform.position;
        StartPositions[2] = AI.transform.position;
        mainCamStartingPos = Camera.main.transform.position;
    }

    public void StartGame()
    {
        if (!gameStarted && !StartScreen.activeInHierarchy && !StoryScreen.activeInHierarchy)
        {
            if(tweener.whichTween != 0)
            {
                StartCoroutine(WaitForTweens(tweener.TweenIt() + 0.5f));
            }
            else
            {
                StartCoroutine(WaitForTweens(0f));
            }
        }
    }


    private IEnumerator WaitForTweens(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<PlayMove>().enabled = true;
        ball.GetComponent<BallMovement>().enabled = true;
        ball.GetComponent<BallMovement>().BallMove();
        AI.GetComponent<AIMovement>().enabled = true;
        gameStarted = true;
    }


    public void RestartGame()
    {
        if(gameStarted)
        {
            if (canBGM)
            { bgm.Stop(); bgm.Play(); }

            gameStarted = false;
            StartScreen.SetActive(true);

            player.GetComponent<PlayMove>().enabled = false;
            ball.GetComponent<BallMovement>().BallStop();
            ball.GetComponent<BallMovement>().enabled = false;
            AI.GetComponent<AIMovement>().enabled = false;
            AI.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ResetPositions();
        }
    }

    private void ResetPositions()
    {
        player.transform.position = StartPositions[0];
        ball.transform.position = StartPositions[1];
        AI.transform.position = StartPositions[2];
        Camera.main.transform.position = mainCamStartingPos;
    }

    public void ToggleCanBGM()
    {
        canBGM = !canBGM;
        if (!canBGM)
            bgm.Pause();
    }

    public void ToggleStory()
    {
        canStory = !canStory;
    }
}
