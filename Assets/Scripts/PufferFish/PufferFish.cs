using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PufferFish : MonoBehaviour
{
    [SerializeField] float oxygenDamage; // The reduction in oxygen on collision
    [SerializeField] string playerTag;
    [SerializeField] float collisionCooldown;
    [HideInInspector] public UnityEvent OnCollide = new UnityEvent();
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
            FindObjectOfType<StatTracking>().IteratePufferCollision();
            oxygen.ReduceOxygen(oxygenDamage);
            collisionTimer = 0f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == playerTag) {
            ReduceOxygen();
        }
    }
}
