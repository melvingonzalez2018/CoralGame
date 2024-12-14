using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] int diveNumber;
    DiveManager diveManager;

    [SerializeField] string upgradeText;
    UpgradeDisplayManager upgradeDisplayManager;

    private void Start() {
        upgradeDisplayManager = FindObjectOfType<UpgradeDisplayManager>(true);
        diveManager = FindObjectOfType<DiveManager>();

        if(diveNumber < diveManager.numberOfDives) {
            diveManager.OnStartDiveEvents[diveNumber].AddListener(UpgradeTrigger);
            diveManager.OnStartDiveEvents[diveNumber].AddListener(CreateUpgradeDisplay);
        }
    }

    private void CreateUpgradeDisplay() {
        upgradeDisplayManager.AddUpgradeText(upgradeText);
    }

    public abstract void UpgradeTrigger();
}
