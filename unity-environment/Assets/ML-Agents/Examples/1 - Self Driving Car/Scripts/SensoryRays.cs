using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensoryRays : MonoBehaviour
{
    public float colorMid;
    public float colorRight;
    public float colorLeft;

    private RaycastHit rayMid;
    private RaycastHit rayRight;
    private RaycastHit rayLeft;

	void Update ()
    {
        //mid
        if (Physics.Raycast(transform.position, Quaternion.AngleAxis(10, Vector3.right) * transform.forward, out rayMid))
        {
            colorMid = rayMid.collider.gameObject.GetComponent<MeshRenderer>().material.color.grayscale;
            Debug.DrawLine(transform.position, rayMid.point);
        }

        //right
        if (Physics.Raycast(transform.position, Quaternion.AngleAxis(10, Vector3.right) * Quaternion.AngleAxis(30, Vector3.up) * transform.forward, out rayRight))
        {
            colorRight = rayRight.collider.gameObject.GetComponent<MeshRenderer>().material.color.grayscale;
            Debug.DrawLine(transform.position, rayRight.point);
        }

        //left
        if (Physics.Raycast(transform.position, Quaternion.AngleAxis(10, Vector3.right) * Quaternion.AngleAxis(-30, Vector3.up) * transform.forward, out rayLeft))
        {
            colorLeft = rayLeft.collider.gameObject.GetComponent<MeshRenderer>().material.color.grayscale;
            Debug.DrawLine(transform.position, rayLeft.point);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(0.2f, 0.2f, 0.2f));

        Gizmos.DrawSphere(rayLeft.point, 0.1f);
        Gizmos.DrawSphere(rayMid.point, 0.1f);
        Gizmos.DrawSphere(rayRight.point, 0.1f);
    }
}
