using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerStun stun;

    [Header("Adjustable Variables")]
    [SerializeField] float horizontalAcceleration;
    [SerializeField] float horizontalMaxSpeed;
    [SerializeField] float verticalAccelleration;
    [SerializeField] float verticalMaxSpeed;
    [SerializeField] float gravityAccel;
    [SerializeField] float maxFallSpeed;
    [SerializeField] float friction;
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
            Vector3 verticalInput = new Vector3(0f, Input.GetAxis("Jump"), 0f);
            Vector3 horizontalInput = camTransform.right * Input.GetAxis("Horizontal") + camTransform.forward * Input.GetAxis("Vertical");
            
            AddVelocity(horizontalInput.normalized * horizontalAcceleration, horizontalMaxSpeed);
            AddVelocity(verticalInput.normalized * verticalAccelleration, verticalMaxSpeed);
        }


        controller.Move(currentVelocity * Time.deltaTime);
    }

    public void AddVelocity(Vector3 velocity, float speedLimit) {
        if(Vector3.Dot(currentVelocity, velocity.normalized) < speedLimit) {
            currentVelocity += velocity;
        }
    }

    private void PhysicsUpdate() {
        // Friction
        if(currentVelocity.magnitude > 0) {
            Vector3 forceOfFriction = (-currentVelocity.normalized) * friction;

            // Setting friction to zero
            if(currentVelocity.magnitude > forceOfFriction.magnitude) {
                currentVelocity += forceOfFriction;
            }
            else {
                currentVelocity = Vector3.zero;
            }
        }

        AddVelocity(Vector3.down * gravityAccel, maxFallSpeed); // Gravity
    }

}
