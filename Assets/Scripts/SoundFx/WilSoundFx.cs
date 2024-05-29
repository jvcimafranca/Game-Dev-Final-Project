using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilSoundFx : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip jumpSfx;
    [SerializeField] private AudioClip hammerSfx;
    [SerializeField] private AudioClip swordSfx;
    [SerializeField] private AudioClip gameOverSfx;
    // [SerializeField] private float num;
    private AudioSource playerSfxSource;
    void Start()
    {
         playerSfxSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSfx()
    {
        playerSfxSource.PlayOneShot(jumpSfx, 1f);
    }
    public void PlayGameOverSfx()
    {
        playerSfxSource.PlayOneShot(gameOverSfx, 1f);
    }

    public void PlayHammerSfx()
    {
        playerSfxSource.PlayOneShot(hammerSfx, 1f);
    }

    public void PlaySwordSfx()
    {
        playerSfxSource.PlayOneShot(swordSfx, 1f);
    }
    
}
