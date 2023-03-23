using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public float jumpforce = 15f;
    public int maxjumps = 2;
    private int jumpsremaining = 0;
    private bool isFacingRight = true;
    public Animator animator;
    bool crouch = false;

    // Add new variable to control collider visibility

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsremaining = maxjumps;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement Horizontal
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (crouch == true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.Space) && jumpsremaining > 0)
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpsremaining--;
        }

        // Toggle collider visibility when button is pressed/released
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
            animator.SetBool("isCrouching", true);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
            animator.SetBool("isCrouching", false);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (horizontal > 0 && !isFacingRight)
        {
            flip();
        }
        else if (horizontal < 0 && isFacingRight)
        {
            flip();
        }
    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jump", false);
            jumpsremaining = maxjumps;
        }
    }
}
