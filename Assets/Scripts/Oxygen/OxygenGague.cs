using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenGague : MonoBehaviour
{
    [SerializeField] Oxygen owner;
    [SerializeField] TMP_Text timerText;
    [SerializeField] ColorTransition gagueEffect; 

    private void Update() {
        timerText.text = GetTimeString(owner.oxygenDuration - owner.timer);
        PlayerStun playerStun = FindObjectOfType<PlayerStun>();
        if(playerStun != null) {
            playerStun.OnLoseOxygen.AddListener(TriggerColor);
        }
    }

    private void TriggerColor() {
        gagueEffect.TriggerColor();
    }

    public string GetTimeString(float time) {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        return timeSpan.ToString(@"mm\:ss");
    }
}
