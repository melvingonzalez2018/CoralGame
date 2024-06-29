using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] Transform freeLookCamera;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Transform camTransform = Camera.main.transform;
        Vector3 playerInput = camTransform.right * Input.GetAxis("Horizontal") + new Vector3(0f, Input.GetAxis("Jump"), 0f) + camTransform.forward * Input.GetAxis("Vertical");
        Vector3 freeLookToPlayer = Camera.main.transform.forward - freeLookCamera.position;
        Vector3 moveDir = Quaternion.FromToRotation(Vector3.forward, Camera.main.transform.forward) * playerInput; // Relative to camera perspective
        controller.Move(playerInput.normalized * speed * Time.deltaTime);
    }
}
