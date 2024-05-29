using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerSoundFx : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip orbSfx;
    [SerializeField] private AudioClip stoneBreakSfx;
    [SerializeField] private AudioClip enemyDeathSfx;
    [SerializeField] private AudioClip playerHurtSfx;
    private AudioSource playerSfxSource;
    void Start()
    {
        playerSfxSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOrbSfx()
    {
        playerSfxSource.PlayOneShot(orbSfx, 0.36f);
    }

    public void PlayStoneBreakSfx()
    {
        playerSfxSource.PlayOneShot(stoneBreakSfx, 1f);
    }

    public void PlayEnemyDeathSfx()
    {
        playerSfxSource.PlayOneShot(enemyDeathSfx, 1f);
    }

    public void PlayHurtSfx()
    {
        playerSfxSource.PlayOneShot(playerHurtSfx, 1f);
    }
}
