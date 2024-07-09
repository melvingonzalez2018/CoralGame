using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultCoral : Coral
{
    bool fragmentAvailable = true;

    public override void Interact() {
        if (fragmentAvailable) {
            FindObjectOfType<CoralStorage>().AddFragment();
            fragmentAvailable = false;
        }
    }

    public override void DiveStartUpdate() {
        if(!fragmentAvailable) {
            fragmentAvailable = true;
        }
    }
}
