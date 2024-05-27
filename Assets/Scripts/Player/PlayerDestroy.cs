using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
   [SerializeField] private GameObject swordPrefab; // Reference to the sword prefab
    [SerializeField] private GameObject bodyPrefab; // Reference to the body prefab
    private Animator playerAnimator;
    private bool isAttacking = false; // To prevent multiple attacks per click
    [SerializeField] private BoxCollider2D swordCollider;
    private ParticleFx particleFx;
    private GameObject objectToDestroy;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        swordPrefab.SetActive(false); // Ensure the sword is initially disabled
        bodyPrefab.SetActive(false); // Ensure the body is initially disabled
        swordCollider = swordPrefab.GetComponent<BoxCollider2D>(); // Get the BoxCollider2D component from the sword prefab
        
        swordCollider.enabled = false; // Ensure the collider is initially disabled
        particleFx = GetComponent<ParticleFx>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !isAttacking) // Check if the left mouse button is clicked
        {
            Attack();
        }
    }

    //  private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // When the player enters the trigger zone, set the flag to true
    //     if (collision.gameObject.CompareTag("Enemy") && isAttacking)
    //     {
    //         // isPlayerInRange = true;
    //         Debug.Log("Enemy is hit!");
    //         // Destroy(collision.gameObject);

    //         EnemyDie enemy = collision.gameObject.GetComponent<EnemyDie>();
    //         if (enemy != null)
    //         {
    //             enemy.TakeHit(); // Increment the hit counter
    //         }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable") && isAttacking)
        {
            Debug.Log("Object is hit!");
            // particleFx.PlayDestroyParticle();
            // objectToDestroy = collision.gameObject;
            // Invoke("DestroyDelay",0.4f);
            
            // EnemyDie enemy = collision.gameObject.GetComponent<EnemyDie>();
            // if (enemy != null)
            // {
            //     enemy.TakeHit(); // Increment the hit counter
            // }
        }

        
    }

    private void DestroyDelay()
        {
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
        }
     private void Attack()
    {
        isAttacking = true;
        // Enable the sword and body prefabs
        swordPrefab.SetActive(true);
        bodyPrefab.SetActive(true);
        swordCollider.enabled = true;
        // Set the isAttacking parameter in the animator to true
        playerAnimator.SetBool("isAttacking", true);

        // Optionally, you can disable the sword and body prefabs after a delay
        StartCoroutine(DisableAfterDelay());
    }

    // Optional: Disable the sword and body after a short delay
    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        swordPrefab.SetActive(false);
        bodyPrefab.SetActive(false);
        swordCollider.enabled = false;
        // Reset the isAttacking parameter in the animator
        playerAnimator.SetBool("isAttacking", false);
        isAttacking = false;
    }
}
