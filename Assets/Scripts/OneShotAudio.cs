using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneShotAudio : MonoBehaviour
{
    AudioSource AudioSource;

    private void Start() {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (!AudioSource.isPlaying) { Destroy(gameObject); }
    }
}
