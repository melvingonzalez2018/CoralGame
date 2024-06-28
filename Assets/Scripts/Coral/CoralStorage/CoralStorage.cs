using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralStorage : MonoBehaviour
{
    List<Coral> corals = new List<Coral>();
    public void AddCoral(Coral coral) {
        corals.Add(coral);
    }

    // Trying to place an object in 
    public bool TryPlaceCoral(CoralPlaceableArea area, Vector3 pos) {
        // Checking position
        if (!area.PositionWithinBounds(pos)) {
            return false;
        }
        
        Coral foundCoral = null;
        foreach (Coral coral in corals) {
            switch(area.areaType) {
                case AreaType.REEF:
                    if(coral.IsAdult()) {
                        if(coral.TryPutDown(area, pos)) {
                            foundCoral = coral;
                        }
                    }
                    break;
                case AreaType.NURSERY:
                    if (!coral.IsAdult()) {
                        if (coral.TryPutDown(area, pos)) {
                            foundCoral = coral;
                        }
                    }
                    break;
            }

            // Breaking early if the coral is found and placed
            if(foundCoral != null) {
                break;
            }
        }

        // Removing the placed coral
        if (foundCoral != null) {
            corals.Remove(foundCoral);
            return true;
        }

        return false;
    }

    public int NumOfAdultCoral() {
        int output = 0;
        foreach (Coral coral in corals) {
            if(coral.IsAdult()) {
                output++;
            }
        }
        return output;
    }
    public int NumOfYoungCoral() {
        int output = 0;
        foreach (Coral coral in corals) {
            if (!coral.IsAdult()) {
                output++;
            }
        }
        return output;
    }
}
