using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongAgent : Agent
{
    public Ball ball;
    public float speed;
    public int score;
    public int paddleSize;
    public Text debugText;

    public override List<float> CollectState()
    {
        List<float> states = new List<float>();

        states.Add(ball.transform.position.x / 75f);
        states.Add(ball.transform.position.y / 50f);

        states.Add(transform.position.y / 50f);

        return states;
    }

    public override void AgentStep(float[] action)
    {
        switch ((int) action[0])
        {
            case 0:
                break;

            case 1:
                if (transform.position.y < 9.5f - transform.localScale.y / 2)
                    transform.position += new Vector3(0, Time.deltaTime * speed, 0);
                break;

            case 2:
                if (transform.position.y > -9.5f + transform.localScale.y / 2)
                    transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
                break;
        }

        if(ball.transform.position.x < ball.borders.left - 3)
        {
            reward = -1;
            done = true;
            score = 0;
        }

        if(score == 5)
        {
            reward = 1;
            done = true;
            score = 0;
        }

        debugText.text = score.ToString();
    }

    public override void AgentReset()
    {
        ball.transform.position = Vector3.zero;
        ball.direction = new Vector3(1, Random.Range(-1f, 1f), 0).normalized;
        ball.GetComponent<TrailRenderer>().Clear();
        transform.position = new Vector3(ball.borders.left + 1, 0, 0);
        transform.localScale = new Vector3(1, FindObjectOfType<PongAcademy>().paddleScale, 1);
    }
}
