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
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        // ADD ANIMATION HERE SCRIPT >>
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if(Input.GetKeyDown(KeyCode.Space) && jumpsremaining > 0)
        {
            animator.SetBool("Jump", true);
            // ADD ANIMATION HERE SCRIPT >>
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpsremaining--;
        }

        if(horizontal > 0 && !isFacingRight)
        {
            flip();
        }
        else if(horizontal < 0 && isFacingRight)
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

        
        if(other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jump", false);
            jumpsremaining = maxjumps;
        }
    }
}
