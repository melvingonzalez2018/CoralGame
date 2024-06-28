using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : MonoBehaviour
{
    [SerializeField] float oxygenDamage; // The reduction in oxygen on collision
    [SerializeField] string playerTag;
    [SerializeField] float collisionCooldown;
    float collisionTimer = 0;
    Oxygen oxygen;

    private void Start() {
        oxygen = FindObjectOfType<Oxygen>();
    }
    private void Update() {
        collisionTimer = Mathf.Min(collisionTimer+Time.deltaTime, collisionCooldown);
    }
    public void ReduceOxygen() {
        if(oxygen != null && collisionTimer >= collisionCooldown) {
            oxygen.ReduceOxygen(oxygenDamage);
            collisionTimer = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == playerTag) {
            ReduceOxygen();
        }
    }
}
