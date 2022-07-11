using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveTrain : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AIMoveToBall aiBrain;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    public void StartBallTraining()
    {
        transform.localPosition = new Vector3(-3.34784293f, 2.98499775f, 0.0284491125f);
        rb.velocity = speed * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void Update()
    {
        if(Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            rb.velocity = speed * new Vector2(Random.Range(-1f, 1f), rb.velocity.y).normalized;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "AI")
        {
            aiBrain.SetReward(1f);
            aiBrain.EndEpisode();
        }

        if(collision.gameObject.name == "Rightwall")
        {
            aiBrain.SetReward(-1f);
            aiBrain.EndEpisode();
        }
    }
}
