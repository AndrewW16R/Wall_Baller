using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    private CircleCollider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        //Gets Rigidbody2D component from gameobject
        rb = GetComponent<Rigidbody2D>();
        
        //Gets CircleCollider2D component from gameobject
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            UpdateBallVelocity();
        }
    }

    private void UpdateBallVelocity()
    {
        //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        rb.AddForce(new Vector2( 5, 10f), ForceMode2D.Impulse);
    }
}
