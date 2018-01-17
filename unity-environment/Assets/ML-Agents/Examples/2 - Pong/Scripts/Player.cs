using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
    }
}
