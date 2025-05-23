using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject ipad;
    [SerializeField] GameObject playerCrosshair;
    [SerializeField] AudioSource endDive;
    [SerializeField] bool unlockBonusLevel = false;

    [Header("Cursor")]
    [SerializeField] Texture2D mouseTex;
    [SerializeField] Vector2 hotspot;

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
        EndScreen endscreenComponent = endScreen.GetComponent<EndScreen>();

        SetPlayerEnable(false);
        FindObjectOfType<StatTracking>().SaveStats(diveManager.currentDive); // saving stats
        endScreen.SetActive(true);
        endscreenComponent.LoadEndScreen(diveManager.currentDive);
        foreach (WaterCurrents current in waterCurrents) {
            current.SetCurrentEffect(false);
        }

        // Playing end dive sound effect
        endDive.Stop();
        endDive.Play();
        

        // Starting new dive
        if(diveManager.IsLastDive()) {
            if(unlockBonusLevel) {
                PlayerPrefs.SetInt("UnlockedBonusLevel", 1);
            }
            endscreenComponent.EndOfLevel();
        }
        else {
            endscreenComponent.EndOfDive();
        }
        ipad.GetComponent<Animator>().SetTrigger("TransitionIn");
    }

    private void SetPlayerEnable(bool value) {
        player.GetComponent<PlayerMovementController>().SetMove(value);
        player.GetComponentInChildren<PlayerInteract>().SetCanInteract(value);
        cameraController.SetRotationControl(value);
        playerCrosshair.SetActive(value);

        if (!value) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(mouseTex, hotspot, CursorMode.Auto);
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
