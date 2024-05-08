using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Transform currentCheckpoint;
    private Health playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        // playerHealth.Respawn();

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            // add sound
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
