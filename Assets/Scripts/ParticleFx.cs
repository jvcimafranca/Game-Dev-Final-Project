using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFx : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDestroyParticle()
    {
        destroyParticle.Play();
    }
}
