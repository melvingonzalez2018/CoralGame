using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject ipad;
    [SerializeField] GameObject playerCrosshair;
    [SerializeField] AudioSource endDive;
    CameraController cameraController;
    DiveManager diveManager;
    GameObject player;
    Vector3 playerInitalPosition;

    List<WaterCurrents> waterCurrents;

    private void Start() {
        diveManager = FindObjectOfType<DiveManager>();
        cameraController = FindObjectOfType<CameraController>();
        player = FindObjectOfType<PlayerMovementController>().gameObject;
        playerInitalPosition = player.transform.position;
        waterCurrents = new List<WaterCurrents>(FindObjectsOfType<WaterCurrents>());


        SetPlayerEnable(false);
    }

    public void StartDive() {
        SetPlayerEnable(true);
        FindObjectOfType<Oxygen>().StartTime();
        foreach (WaterCurrents current in waterCurrents) {
            current.SetCurrentEffect(true);
        }
    }
    public void EndDive() {
        SetPlayerEnable(false);
        endScreen.SetActive(true);
        foreach (WaterCurrents current in waterCurrents) {
            current.SetCurrentEffect(false);
        }

        // Playing end dive sound effect
        endDive.Stop();
        endDive.Play();
        

        // Starting new dive
        if(diveManager.IsLastDive()) {
            endScreen.GetComponent<EndScreen>().EndOfLevel();
            ipad.GetComponent<Animator>().SetTrigger("TransitionIn");
        }
        else {
            endScreen.GetComponent<EndScreen>().EndOfDive();
            ipad.GetComponent<Animator>().SetTrigger("TransitionIn");
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
