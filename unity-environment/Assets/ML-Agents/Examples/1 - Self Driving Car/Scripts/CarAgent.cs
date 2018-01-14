using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarAgent : Agent
{
    [HideInInspector]
    public float horizontal;
    [HideInInspector]
    public float vertical;
    [HideInInspector]
    public bool brake;

    public SensoryRays sensors;
    public Text debugText;

    private int pass;
    private int fail;

    public override List<float> CollectState()
    {
        List<float> states = new List<float>();

        states.Add(sensors.colorLeft);
        states.Add(sensors.colorMid);
        states.Add(sensors.colorRight);

        return states;
    }

    public override void AgentStep(float[] action)
    {
        brake = false;

        switch((int)action[0])
        {
            case 1:
                if (vertical < 1)
                    vertical += Time.deltaTime;
                break;
            
            case 2:
                if (horizontal > -1)
                    horizontal -= Time.deltaTime;
                break;
            
            case 3:
                if (horizontal < 1)
                    horizontal += Time.deltaTime;
                break;
            
            case 4:
                brake = true;
                break;
        }

        if(sensors.colorLeft != 0 && sensors.colorMid != 0 && sensors.colorRight != 0)
        {
            reward = -1;
            done = true;
            fail++;
        }
        else if(transform.position.z > 0)
        {
            reward = 1;
            done = true;
            fail--;
        }
        else if (sensors.colorLeft != 0 && sensors.colorMid == 0 && sensors.colorRight != 0)
        {
            reward = 0.01f;
        }
        else
        {
            reward = -0.01f;
        }

        Debug.Log(sensors.colorLeft + " | " + sensors.colorMid + " | " + sensors.colorRight);
    }

    public override void AgentReset()
    {
        debugText.text = pass + " | " + fail;

        transform.GetComponent<Rigidbody>().isKinematic = true;

        horizontal = 0;
        vertical = 0;

        transform.position = new Vector3(0, 1, -40);
        transform.rotation = Quaternion.identity;

        transform.GetComponent<Rigidbody>().isKinematic = false;
    }
}
