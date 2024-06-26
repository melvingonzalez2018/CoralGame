using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] PlayerStun stun;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        if (!stun.IsStunned()) {
            Transform camTransform = Camera.main.transform;
            Vector3 playerInput = camTransform.right * Input.GetAxis("Horizontal") + new Vector3(0f, Input.GetAxis("Jump"), 0f) + camTransform.forward * Input.GetAxis("Vertical");
            controller.Move(playerInput.normalized * speed * Time.deltaTime);
        }
    }
}
