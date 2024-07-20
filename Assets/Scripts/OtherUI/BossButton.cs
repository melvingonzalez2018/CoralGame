using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossButton : MonoBehaviour
{
    [SerializeField] GameObject notificationIcon;
    [SerializeField] GameObject bossNote;
    DiveManager diveManager;
    bool seen = false;

    private void Start() {
        diveManager = FindObjectOfType<DiveManager>();
        foreach(UnityEvent OnDiveStart in diveManager.OnStartDiveEvents) {
            OnDiveStart.AddListener(ResetSeen);
        }
    }

    private void ResetSeen() {
        seen = false;
        notificationIcon.SetActive(!seen);
    }

    public void ToggleNote() {
        seen = true;
        notificationIcon.SetActive(!seen);
        bossNote.SetActive(!bossNote.activeSelf);
    }
}
