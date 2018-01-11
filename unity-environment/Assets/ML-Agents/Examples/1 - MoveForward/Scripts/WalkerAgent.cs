using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkerAgent : Agent
{
    float velocity = 5f;
    int score;

    WalkerAcademy academy;
    public Text debugText;
    
    Rigidbody rb;
    private float wallScale;
    public Transform wall;

    public override void InitializeAgent()
    {
        rb = GetComponent<Rigidbody>();
        academy = FindObjectOfType<WalkerAcademy>();
    }

    public override List<float> CollectState()
    {
        List<float> states = new List<float>();

        //wall attributes
        states.Add(wallScale / 10f);

        //player attributes
        states.Add(transform.position.x / 5f);
        states.Add(transform.position.z / 5f);

        return states;
    }

    public override void AgentStep(float[] action)
    {
        switch ((int) action[0])
        {
            case 1:
                rb.velocity = new Vector3(-velocity, 0, 0);
                break;
            case 2:
                rb.velocity = new Vector3(velocity, 0, 0);
                break;
            case 3:
                rb.velocity = new Vector3(0, 0, velocity);
                break;
            case 4:
                rb.velocity = new Vector3(0, 0, -velocity);
                break;
            default:
                break;
        }

        reward = -0.01f;

        if (transform.position.x > 5 || transform.position.x < -5 || transform.position.z > 5 || transform.position.z < -5)
        {
            reward = -1;
            done = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Wall")
        {
            reward = 1;
            done = true;
            score++;

            debugText.text = "Score " + score;
        }
    }

    public override void AgentReset()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        wallScale = academy.wallScale;
        wall.localScale = new Vector3(wallScale, 1, 1);
    }
}
