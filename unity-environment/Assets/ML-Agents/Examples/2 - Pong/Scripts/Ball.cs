using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Transform paddle;
    public float hitPoint;
    public bool speedUp;

    [Header("Score Texts")]
    public TextMesh scoreAI;
    public TextMesh scorePL;

    [HideInInspector]
    public Vector3 direction;

    public struct Borders
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

    public Borders borders = new Borders(13f, -13f, -23f, 21f);
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Time.deltaTime * direction * speed;

        if (transform.position.y > borders.top)
        {
            transform.position = new Vector3(transform.position.x, borders.top, 0);
            direction.y *= -1;
        }

        if (transform.position.y < borders.bottom)
        {
            transform.position = new Vector3(transform.position.x, borders.bottom, 0);
            direction.y *= -1;
        }

        if (transform.position.x > borders.right)
        {
            transform.position = new Vector3(borders.right, transform.position.y, 0);
            direction.x *= -1;
        }
        
        PaddleHitCheck();
    }

    private void PaddleHitCheck()
    {
        if (paddle.GetComponent<BoxCollider2D>().bounds.Contains(transform.position))
        {
            transform.position += new Vector3(paddle.localScale.x / 2, 0, 0);

            FindObjectOfType<PongAgent>().reward = 1f;
            FindObjectOfType<PongAgent>().done = true;

            scoreAI.text = (int.Parse(scoreAI.text) + 1).ToString();

            hitPoint = (paddle.position.y - transform.position.y) * 2 / paddle.localScale.y;

            direction.x = -direction.x + 1;
            direction.y -= hitPoint;

            direction.Normalize();
        }
    }
}
