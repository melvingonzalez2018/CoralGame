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
    }

    public void ToggleNote() {
        seen = true;
        bossNote.SetActive(!bossNote.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        notificationIcon.SetActive(!seen);
    }
}
