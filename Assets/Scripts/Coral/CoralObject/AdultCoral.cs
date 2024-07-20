using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultCoral : Coral
{
    [SerializeField] AudioSource harvestSource;
    bool fragmentAvailable = true;

    public bool GetFragmentAvailable() {
        return fragmentAvailable;
    }

    public override void Interact() {
        if (fragmentAvailable) {
            harvestSource.Play();

            int modelIndex = GetComponentInChildren<CoralModel>().currentVisualIndex;
            FindObjectOfType<CoralStorage>().AddFragment(new StoredCoralData(modelIndex));
            fragmentAvailable = false;
        }
    }

    public override void DiveStartUpdate() {
        if(!fragmentAvailable) {
            fragmentAvailable = true;
        }
    }

    public override bool CanInteract() {
        return fragmentAvailable;
    }
}
