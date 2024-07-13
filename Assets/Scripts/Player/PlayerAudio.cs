using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip swimmingClip;
    bool isSwimming = false;

    private void Start() {
        SwimUpdate();
    }

    private void Update() {
        //SwimUpdate();
    }

    private void SwimUpdate() {
        if (isSwimming) {
            audioSource.volume = 1;
        }
        else {
            audioSource.volume = 0;
        }
    }

    public void IsSwimming(bool value) {
        isSwimming = value;
    }
}
