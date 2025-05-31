using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralPutDown : CoralPickup {
    [SerializeField] GameObject coralPrefab;
    private void Start() {
        // keep this here, for some reason if you have a script without any unity specific things it does not compile this script
    }
    public override void AddCoralToStorage(int modelIndex) {
        return; // no implementation
    }
    public override void PlaceCoral(int modelIndex, CoralPlaceableArea area, Vector3 pos) {
        GameObject currentCoral = Instantiate(coralPrefab);
        Coral coral = currentCoral.GetComponent<Coral>();
        coral.GetComponentInChildren<CoralModel>().SetCoralVisual(modelIndex);
        area.MinusCoralCount();
        coral.InitalizeOnArea(area, pos);
    }
}
