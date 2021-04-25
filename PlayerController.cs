using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    bool IsGrounded = false;

    Vector3 Movement;

    public float JumpHeight = 10f;

    void Start()
    {
        GetComponent<Animator>().Play("Player Animation"); 
    }

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");

        if(Movement.x == 0)
        {
            GetComponent<Animator>().Play("Player Animation");
        }
        else
        {
            GetComponent<Animator>().Play("Player_Running");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpHeight), ForceMode2D.Impulse);
            IsGrounded = false;
        }

        transform.position += Movement * Time.fixedDeltaTime * MoveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
}