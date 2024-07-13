using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTanks : Upgrade
{
    /// <summary>
    /// Setting the duration of the oxygen tank, measured in seconds
    /// </summary>
    [SerializeField] float setDuration;

    public override void UpgradeTrigger() {
        Debug.Log("Air Tank upgrade");
        FindObjectOfType<Oxygen>().oxygenDuration = setDuration;
    }
}
