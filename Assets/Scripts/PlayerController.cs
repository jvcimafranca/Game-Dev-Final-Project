using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float horizontalInput;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 15f;
    // private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator playerAnimator;
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;

    [SerializeField] private float extraJumps;
    private float jumpCounter;
    // private bool isOnGround = false;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        Flip();


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            playerAnimator.SetBool("isJumping", true);
            Debug.Log("Jumping");
        }

        else if (Input.GetButtonDown("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
            Debug.Log("SideJumping");
        }

        
        if(IsGrounded())
        {
            Debug.Log("NotJumping");
            coyoteCounter = coyoteTime;
            jumpCounter = extraJumps;
        }

        else
        {
            coyoteCounter -= Time.deltaTime;
        }
        
        
        
    }

    private void FixedUpdate()
    {
        if (horizontalInput > 0.01f || horizontalInput < -0.01f){

            body.velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);
            playerAnimator.SetBool("isWalking", true);

        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {   
        if(coyoteCounter<=0 && jumpCounter<=0) return;

        if(IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
        else
        {
            if(coyoteCounter>0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
            }
            else
            {
                if(jumpCounter>0)
                {
                    body.velocity = new Vector2(body.velocity.x, jumpForce);
                    jumpCounter--;
                }
            }
        }
        coyoteCounter = 0;
        
    }
    private bool IsGrounded()
    {
        // Debug.Log("On Ground");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(-1.5f,1.5f,1.5f);
            playerAnimator.SetBool("isWalking", true);
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            playerAnimator.SetBool("isWalking", true);
        }
        
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }


     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
           
        }
    }
}
