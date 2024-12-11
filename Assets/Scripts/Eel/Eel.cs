using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour {
    [SerializeField] float stunDuration; // The reduction in oxygen on collision
    [SerializeField] string playerTag;
    [SerializeField] float collisionCooldown;
    float collisionTimer = 0;
    AudioSource zapAudio;
    private void Start() {
        zapAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        collisionTimer = Mathf.Min(collisionTimer + Time.deltaTime, collisionCooldown);
    }
    public void StunPlayer(PlayerStun playerStun) {
        if (collisionTimer >= collisionCooldown) {
            FindObjectOfType<StatTracking>().IterateEelCollision();
            playerStun.StunPlayer(stunDuration); // Stun effect
            playerStun.KnockBack(transform.position); // For the sake of knockback
            collisionTimer = 0f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == playerTag) {
            if (other.gameObject.TryGetComponent(out PlayerStun playerStun)) {
                // Play audio
                zapAudio.Stop();
                zapAudio.Play();
                StunPlayer(playerStun);
            }
        }
    }
}
