using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAcademy : Academy
{
    [HideInInspector]
    public float paddleScale;

    public override void AcademyReset()
    {
        paddleScale = resetParameters["paddleScale"];
    }
}
