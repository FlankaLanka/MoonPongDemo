using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private Transform ai;

    [SerializeField] bool isLocal = false; //is real game or not
    private float boundary = 0.34f;

    // Start is called before the first frame update
    void Start()
    {
        ai = this.transform;
        if(isLocal)
        {
            boundary = 2.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.localPosition.y < boundary && ball.localPosition.y > -boundary)
            ai.position = new Vector2(ai.position.x, ball.position.y);
    }
}
