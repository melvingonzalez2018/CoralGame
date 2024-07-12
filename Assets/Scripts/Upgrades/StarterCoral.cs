using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterCoral : Upgrade
{
    /// <summary>
    /// Adding this amount of juvenile coral to the storage
    /// </summary>

    [SerializeField] int amount;
    public override void UpgradeTrigger() {
        Debug.Log("Starter Coral Upgrade");

        CoralStorage storage = FindObjectOfType<CoralStorage>();
        for (int i = 0; i < amount; i++) {
            storage.AddJuvenile();
        }
    }
}
