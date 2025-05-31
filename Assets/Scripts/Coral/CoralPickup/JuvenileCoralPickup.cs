using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuvenileCoralPickup : CoralPickup {
    private void Start() {
        // keep this here, for some reason if you have a script without any unity specific things it does not compile this script
    }
    public override void AddCoralToStorage(int modelIndex) {
        FindAnyObjectByType<CoralStorage>().AddJuvenile(new StoredCoralData(modelIndex));
    }
    public override void PlaceCoral(int modelIndex, CoralPlaceableArea area, Vector3 pos) {
        return; // no implementation
    }
}