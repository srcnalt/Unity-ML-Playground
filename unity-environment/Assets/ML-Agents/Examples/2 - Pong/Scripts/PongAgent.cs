using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAgent : Agent
{
    public Transform ball;
    public float speed;
    public int score;

    public override List<float> CollectState()
    {
        List<float> states = new List<float>();

        states.Add(ball.position.x / 75f);
        states.Add(ball.position.y / 50f);

        states.Add(transform.position.y / 50f);

        return states;
    }

    public override void AgentStep(float[] action)
    {
        switch ((int) action[0])
        {
            case 1:
                if(transform.position.y < 50)
                    GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
                break;

            case 2:
                if (transform.position.y > -50)
                    GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, 0);
                break;
        }

        if(score == 5)
        {
            reward = 1;
            done = true;
            score = 0;
        }
        if(ball.position.x < -80)
        {
            reward = -1;
            done = true;
            score = 0;
        }
    }

    public override void AgentReset()
    {
        ball.position = Vector3.zero;
        ball.GetComponent<Ball>().direction = new Vector3(-1, Random.Range(-1f, 1f), 0).normalized;
        transform.position = new Vector3(-73, 0, 0);
    }
}
