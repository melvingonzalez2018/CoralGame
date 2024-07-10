using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCurrents : MonoBehaviour
{
    [SerializeField] Transform currentDirection;
    [SerializeField] float currentForce;
    [SerializeField] float maxSpeed;
    [SerializeField] string playerTag;
    PlayerMovementController movementController;

    private void Start() {
        movementController = FindObjectOfType<PlayerMovementController>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == playerTag && movementController != null) {
            movementController.AddVelocity(currentForce * currentDirection.forward, maxSpeed);
        }
    }
}
