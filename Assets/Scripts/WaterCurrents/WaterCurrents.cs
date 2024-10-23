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
    bool diveStarted = false;

    private void Start() {
        movementController = FindObjectOfType<PlayerMovementController>();
    }

    public void SetCurrentEffect(bool val) {
        diveStarted = val;
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == playerTag && movementController != null && diveStarted) {
            movementController.AddVelocity(currentForce * currentDirection.forward, maxSpeed);
        }
    }
}
