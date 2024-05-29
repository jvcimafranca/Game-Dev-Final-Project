using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // private bool isPlayerInRange = false;
    private Animator animator;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private float damage;
    private NonPlayerSoundFx nonPlayerSoundFx;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<BoxCollider2D>();
        nonPlayerSoundFx = GetComponent<NonPlayerSoundFx>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (isPlayerInRange)
        // {
        //     animator.SetBool("isAttack", true);
        // }
        // else
        // {
        //     animator.SetBool("isAttack",false);
        // }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // When the player enters the trigger zone, set the flag to true
    //     if (collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player1"))
    //     {
    //         isPlayerInRange = true;
    //         Debug.Log("Player entered trigger zone");
    //         animator.SetBool("isAttack", true);
    //         enemyCollider.size = new Vector3(1.05f, 0.58f); // adjust collider size to explode bomb on a certain radius
    //         

    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     // When the player exits the trigger zone, set the flag to false
    //     if (collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player1"))
    //     {
    //         isPlayerInRange = false;
    //         Debug.Log("Player exited trigger zone");    
    //         animator.SetBool("isAttack", false);
    //         enemyCollider.size = new Vector3(0.59f, 0.58f);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // isPlayerInRange = true;
            Debug.Log("Player entered trigger zone");
            animator.SetBool("isAttack", true);
            enemyCollider.size = new Vector3(1.05f, 0.58f); // adjust collider size to explode bomb on a certain radius
            if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
            {
                nonPlayerSoundFx.PlayHurtSfx();
                collision.GetComponent<Health>().TakeDamage(damage);
            }
            // if (collision.CompareTag("Player2"))
            // {
            //     nonPlayerSoundFx.PlayHurtSfx();
            //     collision.GetComponent<Health>().TakeDamage(damage);
            // }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // isPlayerInRange = false;
            Debug.Log("Player exited trigger zone");    
            animator.SetBool("isAttack", false);
            enemyCollider.size = new Vector3(0.59f, 0.58f);
        }
    }

}
