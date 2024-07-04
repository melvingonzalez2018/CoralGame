using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerStun stun;

    [Header("References")]
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float friction;
    [SerializeField] float gravity;
    Vector3 currentVelocity;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        PhysicsUpdate();

        if (!stun.IsStunned()) {
            // Player Input
            Transform camTransform = Camera.main.transform;
            Vector3 playerInput = camTransform.right * Input.GetAxis("Horizontal") + new Vector3(0f, Input.GetAxis("Jump"), 0f) + camTransform.forward * Input.GetAxis("Vertical");

            currentVelocity += playerInput * acceleration;
        }

        // Setting speed limit
        if(currentVelocity.magnitude > maxSpeed) {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }


        controller.Move(currentVelocity * Time.deltaTime);
    }

    public void AddVelocity(Vector3 velocity) {
        currentVelocity += velocity;
    }

    private void PhysicsUpdate() {
        currentVelocity += (-currentVelocity.normalized) * friction; // Friction
        currentVelocity += Vector3.down * gravity; // Gravity
    }

}
