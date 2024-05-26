using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f; 
    // public Transform leftPoint; 
    // public Transform rightPoint; 
    [SerializeField] private float leftPoint = 0;
    [SerializeField] private float rightPoint = 0;
    [SerializeField] private float zPosition = -0.85f;
    // private Animator animator;

    private bool movingRight = true;
    private Vector2 originalScale; 

    void Start()
    {
        Flip();
        originalScale = transform.localScale;
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Determine the target position based on direction
        float targetX = movingRight ? rightPoint : leftPoint;

        // Move towards the target position
        Vector2 targetPosition = new Vector2(targetX, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        // Move towards the target position while keeping the z position fixed
        // Vector3 targetPosition = new Vector3(targetX, transform.position.y, 0.85f);
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);


        // If reached the target position, change direction and flip the enemy
        if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
        {
            movingRight = !movingRight;
            // animator.SetBool("isAttack", true);
            // animator.SetBool("isWalking", false);
            Flip();
            // animator.SetBool("isAttack", false);
            // animator.SetBool("isWalking", true);
        }
    }


    void Flip()
    {
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
        // animator.SetBool("isAttack", false);
        // animator.SetBool("isWalking", true);
    }
}
