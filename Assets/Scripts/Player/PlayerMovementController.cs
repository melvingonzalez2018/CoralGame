using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerStun stun;
    [SerializeField] SmoothRotateTo rotate;
    [SerializeField] Animator anim;

    [Header("Adjustable Variables")]
    [SerializeField] public float horizontalAcceleration;
    [SerializeField] public float horizontalMaxSpeed;
    [SerializeField] public float verticalAccelleration;
    [SerializeField] public float verticalMaxSpeed;
    [SerializeField] public float gravityAccel;
    [SerializeField] public float maxFallSpeed;
    [SerializeField] public float friction;

    [SerializeField] bool miniGameMode = false;
    Vector3 currentVelocity;

    bool canMove = true;


    private void Update() {
        PhysicsUpdate();

        Vector3 playerInput = Vector3.zero;
        if (!stun.IsStunned() && canMove) {
            // Player Input
            Transform camTransform = Camera.main.transform;
            Vector3 verticalInput = new Vector3(0f, Input.GetAxis("Jump"), 0f);
            Vector3 horizontalInput = camTransform.right * Input.GetAxis("Horizontal") + camTransform.forward * Input.GetAxis("Vertical");

            // Changing forward/backward movement for minigame mode
            if(miniGameMode) { 
                horizontalInput -= camTransform.forward * Input.GetAxis("Vertical");
                verticalInput = Vector3.up * Input.GetAxis("Vertical");
            }

            playerInput = verticalInput + horizontalInput;
            rotate.SetTargetDirection(playerInput.normalized);

            if(horizontalInput.magnitude > 0 && verticalInput.magnitude > 0) {
                AddVelocity(playerInput.normalized * horizontalAcceleration, horizontalMaxSpeed);
            }
            else {
                AddVelocity(horizontalInput.normalized * horizontalAcceleration, horizontalMaxSpeed);
                AddVelocity(verticalInput.normalized * verticalAccelleration, verticalMaxSpeed);
            }
        }
        anim.SetFloat("InputMag", playerInput.magnitude);
        controller.Move(currentVelocity * Time.deltaTime);
    }

    public void SetMove(bool value) {
        canMove = value;
    }
    public void AddVelocity(Vector3 velocity, float speedLimit) {
        speedLimit = Mathf.Max(currentVelocity.magnitude, speedLimit);
        currentVelocity += velocity;
        currentVelocity = Vector3.ClampMagnitude(currentVelocity, speedLimit);
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
