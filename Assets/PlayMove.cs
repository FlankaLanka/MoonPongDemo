using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameObject[] circleSprites;
    private bool allowAnim = false;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        circleSprites = new GameObject[3];
        circleSprites[0] = transform.GetChild(0).gameObject;
        circleSprites[1] = transform.GetChild(2).gameObject;
        circleSprites[2] = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * speed;
            if(allowAnim)
                circleSprites[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * speed;
            if(allowAnim)
                circleSprites[1].SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, 0);
            circleSprites[0].SetActive(false);
            circleSprites[1].SetActive(false);
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
            circleSprites[2].SetActive(false);
        }
    }
}
