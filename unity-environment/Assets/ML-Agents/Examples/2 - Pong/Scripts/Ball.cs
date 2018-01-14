using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    [HideInInspector]
    public Vector3 direction;

    private struct Borders
    {
        public float top, bottom, left, right;

        public Borders(float top, float bottom, float left, float right)
        {
            this.top = top;
            this.bottom = bottom;
            this.left = left;
            this.right = right;
        }
    }
    private Borders borders = new Borders(46, -46, -75, 70);
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Time.deltaTime * direction * speed;

        if (transform.position.y > borders.top || transform.position.y < borders.bottom)
        {
            direction.y *= -1;
        }

        if (transform.position.x > borders.right)
        {
            direction.x *= -1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        direction.x *= -1;

        FindObjectOfType<PongAgent>().reward = 0.5f;
        FindObjectOfType<PongAgent>().score++;
    }
}
