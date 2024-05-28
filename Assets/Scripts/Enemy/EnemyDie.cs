using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private int hitCounter = 0;
    public int maxHits = 3;
    private ParticleFx particleFx;
    private NonPlayerSoundFx nonPlayerSoundFx;
    void Start()
    {
        particleFx = GetComponent<ParticleFx>();
        nonPlayerSoundFx = GetComponent<NonPlayerSoundFx>();
    }
    public void TakeHit()
    {
        hitCounter++;
        Debug.Log("Enemy hit: " + hitCounter);

        if (hitCounter >= maxHits)
        {
            nonPlayerSoundFx.PlayEnemyDeathSfx();
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
