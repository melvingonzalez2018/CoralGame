using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    Vector3 playerInitalPosition;
    private void Start() {
        player = FindObjectOfType<PlayerMovementController>().gameObject;
        playerInitalPosition = player.transform.position;
    }

    public void StartDive() {
        player.transform.position = playerInitalPosition;
        player.GetComponent<PlayerMovementController>().SetMove(true);

        FindObjectOfType<Oxygen>().StartTime();
        FindObjectOfType<Oxygen>().ResetTimer();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
