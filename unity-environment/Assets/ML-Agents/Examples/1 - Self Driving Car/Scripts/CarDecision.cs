using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDecision : MonoBehaviour, Decision
{
    public float[] Decide(List<float> state, List<Camera> observation, float reward, bool done, float[] memory)
    {
        throw new NotImplementedException();
    }

    public float[] MakeMemory(List<float> state, List<Camera> observation, float reward, bool done, float[] memory)
    {
        throw new NotImplementedException();
    }
}
