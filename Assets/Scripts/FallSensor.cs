using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSensor : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] private float damage;
     private bool isDead = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            // collision.GetComponent<Health>().TakeDamage(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Fell");
        if(collision.tag == "Player1" || collision.tag == "Player2")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            // isDead = true;
            // Destroy(collision.gameObject);
            // Invoke("DelayDestroy", 1f);
        }
        if(collision.tag == "Boxes")
        {
            // collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(collision.gameObject);
        }
    }

    private void DelayDestroy()
    {
        // Destroy(collision.gameObject);
    }
}
