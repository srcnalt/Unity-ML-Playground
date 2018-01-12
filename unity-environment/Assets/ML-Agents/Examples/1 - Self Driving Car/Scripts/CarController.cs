using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Parameters")]
    public float motorTorque;
    public float maxSteeringAngle;
    public float brakeTorque;

    [Header("Axle Info")]
    public List<Axle> axles;
    	
	void FixedUpdate()
    {
        float motor = Input.GetAxis("Vertical") * motorTorque;
        float steer = Input.GetAxis("Horizontal") * maxSteeringAngle;

        foreach (Axle axle in axles)
        {
            if (axle.isMotor)
            {
                axle.colLeft.motorTorque = motor;
                axle.colRight.motorTorque = motor;

                if (Input.GetKey(KeyCode.Space))
                {
                    axle.colLeft.brakeTorque = brakeTorque * 1000;
                    axle.colRight.brakeTorque = brakeTorque * 1000;
                }
                else if(axle.colLeft.brakeTorque != 0 || axle.colRight.brakeTorque != 0)
                {
                    axle.colLeft.brakeTorque = Mathf.Lerp(axle.colLeft.brakeTorque, 0, brakeTorque / 10);
                    axle.colRight.brakeTorque = Mathf.Lerp(axle.colRight.brakeTorque, 0, brakeTorque / 10);
                }
            }

            if (axle.canSteer)
            {
                axle.colLeft.steerAngle = steer;
                axle.colRight.steerAngle = steer;
            }

            ApplyVisuals(axle.colRight, axle.right);
            ApplyVisuals(axle.colLeft, axle.left);
        }
    }

    private void ApplyVisuals(WheelCollider coll, Transform t)
    {
        Vector3 visualPosition;
        Quaternion visualRotation;

        coll.GetWorldPose(out visualPosition, out visualRotation);

        t.position = visualPosition;
        t.rotation = visualRotation;
    }
}

[System.Serializable]
public class Axle
{
    public WheelCollider colRight;
    public WheelCollider colLeft;

    public Transform right;
    public Transform left;

    public bool isMotor;
    public bool canSteer; 
}
