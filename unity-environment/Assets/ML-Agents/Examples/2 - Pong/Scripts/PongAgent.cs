using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongAgent : Agent
{
    public Ball ball;
    public float speed;
    public int paddleSize;

    public override List<float> CollectState()
    {
        List<float> states = new List<float>();

        states.Add(ball.transform.position.x / 12f);
        states.Add(ball.transform.position.y / 23f);

        states.Add(transform.position.y / 19f);

        states.Add(ball.direction.x);
        states.Add(ball.direction.y);

        return states;
    }

    public override void AgentStep(float[] action)
    {
        switch ((int) action[0])
        {
            case 0:
                reward = 0.001f;
                break;
            case 1:
                if (transform.position.y < ball.borders.top - transform.localScale.y / 2)
                    //transform.position += new Vector3(0, Time.deltaTime * speed, 0);
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                break;

            case 2:
                if (transform.position.y > ball.borders.bottom + transform.localScale.y / 2)
                    //transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                break;
        }

        if(ball.transform.position.x < ball.borders.left - 3)
        {
            reward = -1;
            done = true;

            ball.scorePL.text = (int.Parse(ball.scorePL.text) + 1).ToString();
        }
    }

    public override void AgentReset()
    {
        ball.transform.position = new Vector3(0, 0, 0);
        ball.direction = new Vector3(Random.Range(0.1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        ball.GetComponent<TrailRenderer>().Clear();
        transform.position = new Vector3(-22, 0, 0);

        transform.localScale = new Vector3(1, FindObjectOfType<PongAcademy>().paddleScale, 1);
    }
}
