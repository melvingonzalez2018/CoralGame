using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class StatTrackingUI : MonoBehaviour
{
    [SerializeField] StatTracking owner;
    [SerializeField] TMP_Text reefDensity;
    [SerializeField] TMP_Text trashCollected;
    [SerializeField] TMP_Text trashTotal;
    [SerializeField] TMP_Text fragmentsHarvested;
    [SerializeField] TMP_Text coralsHammered;
    [SerializeField] TMP_Text fishDisturbed;

    public int textCountDuration; 
    List<UITextCount> UITextCounts = new List<UITextCount>();
    ImageRadialFill fill;

    private void Start() {
        // Getting and setting the duration for text counts
        UITextCounts = GetComponentsInChildren<UITextCount>().ToList<UITextCount>();
        foreach(UITextCount textCount in UITextCounts) {
            textCount.duration = textCountDuration;
        }
        fill = GetComponentInChildren<ImageRadialFill>();
        fill.duration = textCountDuration;
    }

    public void LoadStats(int diveNumber) {
        DiveStats diveStats = owner.stats[diveNumber];
        UITextCount densityUI = reefDensity.GetComponent<UITextCount>();
        densityUI.ending = "%";
        densityUI.scale = Mathf.Clamp01(diveStats.coralPlaced / owner.totalCoralPlaceable) * 100;
        fill.scale = Mathf.Clamp01(diveStats.coralPlaced / owner.totalCoralPlaceable);
        trashCollected.GetComponent<UITextCount>().scale = diveStats.trashCollected;
        trashTotal.GetComponent<UITextCount>().scale = owner.trashTotal;
        fragmentsHarvested.GetComponent<UITextCount>().scale = diveStats.coralFragmentsPickedup;
        coralsHammered.GetComponent<UITextCount>().scale = diveStats.coralHammered;
        fishDisturbed.GetComponent<UITextCount>().scale = diveStats.eelCollisions + diveStats.pufferCollisions;

        // Activating all of them
        foreach (UITextCount textCount in UITextCounts) {
            textCount.Activate();
        }
        fill.Activate();
    }
}
