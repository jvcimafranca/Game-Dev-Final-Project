using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set;}
    private AudioSource audioSource;
    // [SerializeField] private AudioClip introMusic;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip _sound) // for SoundFx
    {
        audioSource.PlayOneShot(_sound);
    }


}
