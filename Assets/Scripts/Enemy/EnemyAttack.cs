using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player enters the trigger zone, set the flag to true
        if (collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player1"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered trigger zone");
            animator.SetBool("isAttack", true);


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // When the player exits the trigger zone, set the flag to false
        if (collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player1"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited trigger zone");
            animator.SetBool("isAttack", false);
        }
    }
}
