using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject CollectingItem;

    public Rigidbody2D Rb;

    public float MoveSpeed = 10f;

    public float JumpHeight = 10f;

    Vector3 Movement;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        Movement.x = 0;

        if (Movement.x == 0)
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
        Movement.x = 1;

        if (transform.position.x > CollectingItem.gameObject.transform.position.x)
        {
            Movement.x = -1;
        }

        if (Movement.x == 0)
        {
            GetComponent<Animator>().Play("Player Animation");
        }
        else
        {
            GetComponent<Animator>().Play("Player_Running");
        }

        transform.position += Movement * Time.fixedDeltaTime * MoveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpHeight), ForceMode2D.Impulse);
        }
    }
}
