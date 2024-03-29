﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDecision : MonoBehaviour, Decision
{
    public float[] Decide(List<float> state, List<Camera> observation, float reward, bool done, float[] memory)
    {
        float[] action = new float[1];

        action[0] = Random.Range(1, 4);

        return action;
    }

    public float[] MakeMemory(List<float> state, List<Camera> observation, float reward, bool done, float[] memory)
    {
        return new float[1];
    }
}
