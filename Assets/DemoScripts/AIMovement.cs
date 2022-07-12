using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private Rigidbody2D rb;

    private GameObject[] circleSprites;
    private bool prevY = false;
    private bool curY = false;

    private bool allowAnim = false;

    // Start is called before the first frame update
    void Start()
    {
        circleSprites = new GameObject[3];
        circleSprites[0] = transform.GetChild(0).gameObject;
        circleSprites[1] = transform.GetChild(2).gameObject;
        circleSprites[2] = transform.GetChild(1).gameObject;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.position.y > transform.position.y)
        {
            rb.velocity = new Vector2(0, 3f);
            curY = true;
        }
        else if(ball.position.y < transform.position.y)
        {
            rb.velocity = new Vector2(0, -3f);
            curY = false;
        }

        if(curY != prevY && allowAnim)
        {
            prevY = curY;
            if(curY)
            {
                circleSprites[0].SetActive(true);
                circleSprites[1].SetActive(false);
            }
            else
            {
                circleSprites[0].SetActive(false);
                circleSprites[1].SetActive(true);
            }
        }
    }

    public void ToggleAnim()
    {
        allowAnim = !allowAnim;
        if (allowAnim)
        {
            circleSprites[2].SetActive(true);
        }
        else
        {
            circleSprites[0].SetActive(false);
            circleSprites[1].SetActive(false);
            circleSprites[2].SetActive(false);
        }
    }
}
