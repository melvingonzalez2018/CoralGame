using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour {
    [SerializeField] float stunDuration; // The reduction in oxygen on collision
    [SerializeField] string playerTag;
    [SerializeField] float collisionCooldown;
    float collisionTimer = 0;

    private void Update() {
        collisionTimer = Mathf.Min(collisionTimer + Time.deltaTime, collisionCooldown);
    }
    public void StunPlayer(PlayerStun playerStun) {
        if (collisionTimer >= collisionCooldown) {
            FindObjectOfType<StatTracking>().IterateEelCollision();
            playerStun.StunPlayer(stunDuration);
            collisionTimer = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == playerTag) {
            if(collision.gameObject.TryGetComponent(out PlayerStun playerStun)) {
                StunPlayer(playerStun);
            }
        }
    }
}
