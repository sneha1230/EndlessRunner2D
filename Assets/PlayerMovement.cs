using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D playerRB;
    public float jumpVelocity;
    bool grounded = false;
    Animator animator;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (grounded)
            {
                Jump();
                animator.SetTrigger("Jump");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            animator.SetTrigger("Dead");
        }
    }
    private void Jump()
    {
        grounded = false;
        playerRB.velocity = new Vector2(0, jumpVelocity);
    }
}
