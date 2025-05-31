using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoseOxygenEffect : MonoBehaviour
{
    List<ParticleSystem> totalParticleSystems;
    // Start is called before the first frame update
    void Start() {
        totalParticleSystems = GetComponentsInChildren<ParticleSystem>().ToList<ParticleSystem>();
    }

    public void TriggerParticle() {
        // Getting all non active particles
        List<ParticleSystem> nonActiveParticles = new List<ParticleSystem>();
        foreach(ParticleSystem particle in totalParticleSystems) {
            if(!particle.isPlaying) {
                nonActiveParticles.Add(particle);
            }
        }

        // If there are non active particles play one at random
        if(nonActiveParticles.Count > 0) {
            int randI = Random.Range(0, nonActiveParticles.Count);
            nonActiveParticles[randI].Play();
        }
    }
}
