using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject newsScreen;
    [SerializeField] GameObject playerCrosshair;
    CameraController cameraController;
    DiveManager diveManager;
    GameObject player;
    Vector3 playerInitalPosition;

    private void Start() {
        diveManager = FindObjectOfType<DiveManager>();
        cameraController = FindObjectOfType<CameraController>();
        player = FindObjectOfType<PlayerMovementController>().gameObject;
        playerInitalPosition = player.transform.position;

        SetPlayerEnable(false);
    }

    public void StartDive() {
        SetPlayerEnable(true);
        FindObjectOfType<Oxygen>().StartTime();
    }
    public void EndDive() {
        SetPlayerEnable(false);
        endScreen.SetActive(true);

        // Starting new dive
        if(diveManager.IsLastDive()) {
            endScreen.GetComponent<EndScreen>().EndOfLevel();
        }
        else {
            endScreen.GetComponent<EndScreen>().EndOfDive();
        }
    }

    private void SetPlayerEnable(bool value) {
        player.GetComponent<PlayerMovementController>().SetMove(value);
        player.GetComponentInChildren<PlayerInteract>().SetCanInteract(value);
        cameraController.SetRotationControl(value);
        playerCrosshair.SetActive(value);

        if (!value) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ResetLevel() {
        FindObjectOfType<Oxygen>().ResetTimer();
        player.transform.position = playerInitalPosition;
    }
}