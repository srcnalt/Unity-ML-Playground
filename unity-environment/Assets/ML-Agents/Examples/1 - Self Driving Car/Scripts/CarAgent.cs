using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAgent : Agent
{
    [HideInInspector]
    public float horizontal;
    [HideInInspector]
    public float vertical;
    [HideInInspector]
    public bool brake;

    public override List<float> CollectState()
    {
        return base.CollectState();
    }

    public override void AgentStep(float[] action)
    {
        Debug.Log(action[0]);

        brake = false;

        switch((int)action[0])
        {
            case 1:
                if (vertical < 1)
                    vertical += Time.deltaTime;
                break;

            case 2:
                if (horizontal < 1)
                    horizontal += Time.deltaTime;
                break;

            case 3:
                if (horizontal > -1)
                    horizontal -= Time.deltaTime;
                break;

            case 4:
                brake = true;
                break;
        }
    }

    public override void AgentReset()
    {
        base.AgentReset();
    }
}
