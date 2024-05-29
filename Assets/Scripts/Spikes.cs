using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float damage;
    private NonPlayerSoundFx nonPlayerSoundFx;
    void Start()
    {
        nonPlayerSoundFx = GetComponent<NonPlayerSoundFx>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Spike Trigger");
        if(collision.tag == "Player1")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            nonPlayerSoundFx.PlayHurtSfx();
        }
    }
}
