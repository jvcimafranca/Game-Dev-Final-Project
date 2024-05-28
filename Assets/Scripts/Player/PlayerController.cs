using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float moveSpeed = 8f;
    // [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float decelerationRate = 0.1f;
    // private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator playerAnimator;
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float extraJumps;
    private WilSoundFx wilSoundFx;

     // Boundary limits
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    private float jumpCounter;
    private float currentSpeed;
    private bool enemyInProximity = false;
    private bool inLevel3 = false;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        wilSoundFx = GetComponent<WilSoundFx>(); // gets the component from another script
    }

    // Update is called once per frame
    void Update() 
    {
        if(gameManager.IsGameActive())
        {
            verticalInput = Input.GetAxisRaw("Vertical");

            Flip();

            if(enemyInProximity && inLevel3)
            {
                extraJumps = 0;
            }
            else if (!enemyInProximity && inLevel3) 
            {
                extraJumps = 1;
            }
            // Coyote Time Management
            if (IsGrounded()) {
                coyoteCounter = coyoteTime;
                jumpCounter = extraJumps; // Reset jumpCounter when grounded
                playerAnimator.SetBool("isJumping", false); // Reset jumping animation
            } else {
                coyoteCounter -= Time.deltaTime; // Decrease coyoteCounter over time
            }

            // if (Input.GetButtonDown("Jump"))) {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (coyoteCounter > 0 || jumpCounter > 0) {
                    Jump(); // Trigger jump if within coyote time or if additional jumps are available
                    
                }
            }
            if(verticalInput<-0.01f){
                body.velocity = new Vector2(body.velocity.x, -jumpForce);
            }

             // Clamp the player's position within the screen boundaries
            ClampPosition();
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.IsGameActive())
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Mathf.Abs(horizontalInput) > 0.25f)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, horizontalInput * moveSpeed, decelerationRate);
                playerAnimator.SetBool("isWalking", true);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, decelerationRate);
                playerAnimator.SetBool("isWalking", false);
            }

            body.velocity = new Vector2(currentSpeed, body.velocity.y);
        }
    }

    void Jump() 
    {   
        // playerAnimator.SetBool("isJumping", true); 
        if (IsGrounded() || coyoteCounter > 0 || jumpCounter > 0) {
            body.velocity = new Vector2(body.velocity.x, jumpForce); // Apply jump force
            wilSoundFx.PlayJumpSfx();
            if (!IsGrounded()) {
                if (jumpCounter > 0) {
                    jumpCounter--; // Decrement extra jumps when using double jump
                }
            }

            coyoteCounter = 0; // Reset coyote time after jumping
        }
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


    private void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player enters the trigger zone, set the flag to true
        if (collision.CompareTag("EnemyProximity"))
        {
            // if (collision.CompareTag("Level3"))
            // {
                enemyInProximity = true;
                Debug.Log("Enemy in Proximity");
            // }
            
        }

        if (collision.CompareTag("Level3"))
        {
                inLevel3 = true;
                Debug.Log("Enemy in Level3");
        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // When the player exits the trigger zone, reset the flag to false
        if (collision.CompareTag("EnemyProximity"))
        {
            // if (collision.CompareTag("Level3"))
            // {
                enemyInProximity = false;
                Debug.Log("Enemy not in Proximity");
            // }
        }

        if (collision.CompareTag("Level3"))
        {
                inLevel3 = false;
                Debug.Log("Enemy not in Level3");
        
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // When the player enters the trigger zone, set the flag to true
    //     if (collision.CompareTag("Level3"))
    //     {
    //         // if (collision.CompareTag("Level3"))
    //         // {
    //             inLevel3 = true;
    //             Debug.Log("Enemy in Level3");
    //         // }
            
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     // When the player exits the trigger zone, reset the flag to false
    //     if (collision.CompareTag("Level3"))
    //     {
    //         // if (collision.CompareTag("Level3"))
    //         // {
    //             inLevel3 = false;
    //             Debug.Log("Enemy in Level3");
    //         // }
    //     }
    // }
}
