using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        Vector3 moveDir = Quaternion.FromToRotation(Vector3.forward, Camera.main.transform.forward) * playerInput; // Relative to camera perspective
        controller.Move(moveDir.normalized * speed * Time.deltaTime);
    }
}
