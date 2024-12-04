using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCoralPickup : CoralPickup {
    public override void AddCoralToStorage(int modelIndex) {
        FindAnyObjectByType<CoralStorage>().AddFragment(new StoredCoralData(modelIndex));
        FindObjectOfType<StatTracking>().IterateCoralPickup();
    }
}