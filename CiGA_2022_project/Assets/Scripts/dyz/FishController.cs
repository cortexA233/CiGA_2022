using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private float speed;
    private int lookDirection;
    private Rigidbody2D rigidbody;
    private Vector2 begin;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        lookDirection = (Random.Range(0, 2) == 0) ? 1 : -1;

        speed = Random.Range(100f, 200f);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidbody.velocity = new Vector2(lookDirection * speed * Time.deltaTime, rigidbody.velocity.y);
    }

    void Flip()
    {
        lookDirection *= -1;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Enter");
        if (other.CompareTag("Wall"))
        {
            // Debug.Log("Flip");
            Flip();
        }
    }
}
