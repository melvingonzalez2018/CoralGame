using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject newsScreen;
    DiveManager diveManager;
    GameObject player;
    Vector3 playerInitalPosition;
    private void Start() {
        diveManager = FindObjectOfType<DiveManager>();
        player = FindObjectOfType<PlayerMovementController>().gameObject;
        playerInitalPosition = player.transform.position;
    }

    public void StartDive() {
        ResetLevel();

        player.GetComponent<PlayerMovementController>().SetMove(true);
        FindObjectOfType<Oxygen>().StartTime();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void EndDive() {
        player.GetComponent<PlayerMovementController>().SetMove(false);
        endScreen.SetActive(true);

        // Starting new dive
        if(diveManager.StartNewDive()) {
            endScreen.GetComponent<EndScreen>().EndOfDive();
        }
        else {
            diveManager.UpdateCoral();
            endScreen.GetComponent<EndScreen>().EndOfLevel();
        }
    }

    public void ResetLevel() {
        FindObjectOfType<Oxygen>().ResetTimer();
        player.transform.position = playerInitalPosition;
    }
}
