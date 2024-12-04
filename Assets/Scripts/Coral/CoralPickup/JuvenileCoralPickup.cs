using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuvenileCoralPickup : CoralPickup {
    public override void AddCoralToStorage(int modelIndex) {
        FindAnyObjectByType<CoralStorage>().AddJuvenile(new StoredCoralData(modelIndex));
        FindObjectOfType<StatTracking>().IterateCoralPickup();
    }
}