using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private int hitCounter = 0;
    public int maxHits = 3;

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
        Destroy(gameObject);
    }
}
