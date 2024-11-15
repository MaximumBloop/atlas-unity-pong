using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float SPEED = 400.0f;
    private Vector2 moveDirectionV;
    public Rigidbody2D rb;

    public Score scoreboard;

    public Canvas canvas;

    public Camera camera;
    private RectTransform canvasRectTransform;

    private float top;
    private float bottom;
    // Start is called before the first frame update
    void Start()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        resetBallPosition();
        resetBallVelocity(SPEED);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // reflects off the top/bottom of screen
        if (transform.position.y > canvasRectTransform.rect.height ||
            transform.position.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }

        // just in case the ball moves insanely fast
        // and goes beyond the bounds for some reason
        if (transform.position.y > canvasRectTransform.rect.height)
        {
            transform.position = new Vector2(transform.position.x, canvasRectTransform.rect.height);
        } else if (transform.position.y < 0)
        {
            transform.position = new Vector2(transform.position.x, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            other.gameObject.GetComponentInChildren<Score>().scoreGoal();
            if (other.gameObject.GetComponentInChildren<Score>().score < 11)
            {
                resetBallPosition();
                resetBallVelocity(SPEED);
            }
        }
        if (other.CompareTag("Paddle"))
        {
            //slap dat ball back to the right/left
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    internal void resetBallPosition()
    {
        rb.position = new Vector2(Screen.width / 2, Screen.height / 2);
        rb.isKinematic = true;
    }

    internal void resetBallVelocity(float speed)
    {
        rb.velocity = (Random.Range(0, 2) == 0) ? new Vector2(1, 1): new Vector2(-1, 1);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y) * speed;
    }
}
