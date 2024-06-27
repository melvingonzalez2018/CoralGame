using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralStorage : MonoBehaviour
{
    List<Coral> corals = new List<Coral>();
    public void AddCoral(Coral coral) {
        corals.Add(coral);
        Debug.Log("added");
    }

    // Trying to place an object in 
    public bool TryPlaceCoral(CoralPlaceableArea area, Vector3 pos) {
        foreach(Coral coral in corals) {
            bool found = false;
            switch(area.areaType) {
                case AreaType.REEF:
                    if(coral.IsAdult()) {
                        coral.PutDown(area, pos);
                        found = true;
                    }
                    break;
                case AreaType.NURSERY:
                    if (!coral.IsAdult()) {
                        coral.PutDown(area, pos);
                        found = true;
                    }
                    break;
            }

            // Breaking early if the coral is found and placed
            if(found) {
                return true;
            }
        }

        Debug.Log("Not found area");

        return false;
    }
}
