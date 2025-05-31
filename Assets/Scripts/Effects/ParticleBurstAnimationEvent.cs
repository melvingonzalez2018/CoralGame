using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurstAnimationEvent : MonoBehaviour
{
    [SerializeField] ParticleSystem system;

    public void PlayBurst() {
        system.Play();
    }
}
