using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private int hitCounter = 0;
    public int maxHits = 3;
    private ParticleFx particleFx;
    void Start()
    {
        particleFx = GetComponent<ParticleFx>();
    }
    public void TakeHit()
    {
        hitCounter++;
        Debug.Log("Enemy hit: " + hitCounter);

        if (hitCounter >= maxHits)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy killed!");
        particleFx.PlayDestroyParticle();
        // Destroy(gameObject);
        Invoke("DestroyDelay",0.5f);
    }

    private void DestroyDelay()
    {
        Destroy(this.gameObject);
    }
}
