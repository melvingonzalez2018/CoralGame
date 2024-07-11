using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralStorage : MonoBehaviour {
    [SerializeField] GameObject juvenileCoralPrefab;
    [SerializeField] GameObject fragmentedCoralPrefab;
    public int fragmentCoral = 0;
    public int juvenileCoral = 0;

    public void AddJuvenile() {
        juvenileCoral++;
    }

    public void AddFragment() {
        fragmentCoral++;
    }

    // Trying to place an object in 
    public bool TryPlaceCoral(CoralPlaceableArea area, Vector3 pos) {
        // Checking position
        if (!area.PositionWithinBounds(pos)) {
            return false;
        }

        switch (area.areaType) {
            case AreaType.REEF:
                if (juvenileCoral > 0) {
                    GameObject currentCoral = Instantiate(juvenileCoralPrefab);
                    Coral coral = currentCoral.GetComponent<Coral>();
                    coral.InitalizeOnArea(area, pos);
                    juvenileCoral--;
                }
                break;
            case AreaType.NURSERY:
                if (fragmentCoral > 0) {
                    GameObject currentCoral = Instantiate(fragmentedCoralPrefab);
                    Coral coral = currentCoral.GetComponent<Coral>();
                    coral.InitalizeOnArea(area, pos);
                    fragmentCoral--;
                }
                break;
        }
        return false;
    }
}
