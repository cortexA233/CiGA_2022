using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private bool canMove;
    private bool beAttracked;
    private float speed;
    private float speedUp;
    private int lookDirection;
    private Rigidbody2D rigidbody;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        lookDirection = (Random.Range(0, 2) == 0) ? 1 : -1;

        canMove = true;

        beAttracked = false;

        speed = Random.Range(100f, 200f);

        speedUp = 0.1f;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (GameObject.Find("bait") == null)
        {
            canMove = true;
            beAttracked = false;
        }
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
        if (canMove)
        {
            if (beAttracked)
            {
                rigidbody.velocity = new Vector2(lookDirection * speed * (1 + speedUp) * Time.deltaTime, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(lookDirection * speed * Time.deltaTime, rigidbody.velocity.y);
            }
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    void Flip()
    {
        lookDirection *= -1;

        transform.localScale = new Vector3(lookDirection, 0.586f, 1);
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

        if (other.CompareTag("Bait"))
        {
            // Debug.Log("Bait");
            canMove = false;
        }
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("Stay");
        if (other.CompareTag("AttrackRange"))
        {
            // Debug.Log("Attracked");
            beAttracked = true;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Exit");
        if (other.CompareTag("AttrackRange") || other.CompareTag("Bait"))
        {
            beAttracked = false;
            canMove = true;
        }
    }
}
