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

        // Getting amount of models
        CoralModel coralModel = FindObjectOfType<CoralModel>();
        int modelAmount = 0;
        if (coralModel != null) {
            modelAmount = coralModel.coralModels.Count;
        }

        for (int i = 0; i < amount; i++) {
            // Adding randdomized juveniles 
            int modelIndex = Mathf.FloorToInt(Random.value * modelAmount); // Finding random model
            if(modelIndex == modelAmount) { modelIndex--; } // Dealing with edge case
            storage.AddJuvenile(new StoredCoralData(modelIndex)); // Setting model
        }
    }
}
