using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementNetwork : NetworkBehaviour
{
    [SerializeField]
    private float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if(isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector2.up * speed;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.down * speed;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
    }
}
