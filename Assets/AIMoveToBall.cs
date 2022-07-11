using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AIMoveToBall : Agent
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float moveSpeed = 0.05f;
    [SerializeField] private GameObject endEpisodeResultColor;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(1.44215703f, 2.98499775f, 0.0284491125f);
        ball.GetComponent<BallMoveTrain>().StartBallTraining();

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discrete = actionsOut.DiscreteActions;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            discrete[0] = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            discrete[0] = 2;
        }
        else
        {
            discrete[0] = 0;
        }
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        //Debug.Log(actions.DiscreteActions[0]);

        if (actions.DiscreteActions[0] == 2) //move down
        {
            transform.localPosition += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        }
        else if (actions.DiscreteActions[0] == 1) //move up
        {
            transform.localPosition += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }
        else if (actions.DiscreteActions[0] == 0)
        {
            //don't move
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Topwall" || collision.gameObject.name == "Bottomwall")
        {
            SetReward(-0.5f);
            endEpisodeResultColor.GetComponent<SpriteRenderer>().color = Color.red;
            EndEpisode();
        }
    }

}
