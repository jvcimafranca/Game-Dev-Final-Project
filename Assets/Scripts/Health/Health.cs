using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth{get; private set;}
    private Animator playerAnimator;
    private bool dead;
    void Start()
    {
        playerAnimator = GetComponent<Animator>(); 
    }
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            playerAnimator.SetTrigger("Hurt");
            Debug.Log("Hurt");
        }
        else
        {
            if(!dead)
            {
                playerAnimator.SetTrigger("Die");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
            }
           
        }
    }

    public void AddHealth(float _value)
    {   
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
