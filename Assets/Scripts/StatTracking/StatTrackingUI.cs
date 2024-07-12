using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatTrackingUI : MonoBehaviour
{
    [SerializeField] StatTracking owner;
    [SerializeField] TMP_Text text;

    private void Update() {
        UpdateUI();
    }

    private void UpdateUI() {
        AdultCoral[] corals = FindObjectsOfType<AdultCoral>();
        float adultCoralPercent = (float)corals.Length / owner.adultCoralGoal;
        adultCoralPercent = Mathf.Floor(adultCoralPercent * 100f);

        string output = "Coral Percent: " + adultCoralPercent + "%" + "\n" +
            "Coral Pickup: " + owner.coralPickup + "\n" +
            "Coral Hammered: " + owner.coralHammered + "\n" +
            "Coral Grown: " + owner.coralGrown + "\n" +
            "Trash Collected: " + owner.trashCollected + "/" + owner.trashTotal + "\n" +
            "Eel Collisions: " + owner.eelCollisions + "\n" +
            "Puffer Collisions: " + owner.pufferCollisions;
        text.text = output;
    }
}
