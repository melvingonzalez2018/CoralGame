using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip swimmingClip;
    bool isSwimming = false;

    private void Update() {
        SwimUpdate();
    }

    private void SwimUpdate() {
        if(!audioSource.isPlaying && isSwimming) {
            audioSource.Play();
        }
    }

    public void IsSwimming(bool value) {
        isSwimming = value;
    }
}
