using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] int diveNumber;
    DiveManager diveManager;
    private void Start() {
        diveManager = FindObjectOfType<DiveManager>();

        if(diveNumber < diveManager.numberOfDives) {
            diveManager.OnStartDiveEvents[diveNumber].AddListener(UpgradeTrigger);
        }
    }
    public abstract void UpgradeTrigger();
}
