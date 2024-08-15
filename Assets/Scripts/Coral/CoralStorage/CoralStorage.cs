using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StoredCoralData {
    public int modelIndex;

    public StoredCoralData(int modelIndex) {
        this.modelIndex = modelIndex;
    }
}



public class CoralStorage : MonoBehaviour {
    [SerializeField] GameObject juvenileCoralPrefab;
    [SerializeField] GameObject fragmentedCoralPrefab;
    public Queue<StoredCoralData> fragmentCoral = new Queue<StoredCoralData>();
    public Queue<StoredCoralData> juvenileCoral = new Queue<StoredCoralData>();

    public void AddJuvenile(StoredCoralData coralData) {
        juvenileCoral.Enqueue(coralData);
    }

    public void AddFragment(StoredCoralData coralData) {
        fragmentCoral.Enqueue(coralData);
    }

    public int GetFragmentCount() {
        return fragmentCoral.Count;
    }

    public int GetJuvenileCount() {
        return juvenileCoral.Count;
    }

    // Trying to place an object in 
    public bool TryPlaceCoral(CoralPlaceableArea area, Vector3 pos) {
        // Checking position
        if (!area.PositionWithinBounds(pos)) {
            return false;
        }
        if(!area.CanPlaceCoral()) {
            return false;
        }

        switch (area.areaType) {
            case AreaType.REEF:
                if (GetJuvenileCount() > 0) {
                    StoredCoralData coralData = juvenileCoral.Dequeue();

                    GameObject currentCoral = Instantiate(juvenileCoralPrefab);
                    Coral coral = currentCoral.GetComponent<Coral>();
                    coral.InitalizeOnArea(area, pos);
                    coral.GetComponentInChildren<CoralModel>().SetCoralVisual(coralData.modelIndex);
                }
                break;
            case AreaType.NURSERY:
                if (GetFragmentCount() > 0) {
                    StoredCoralData coralData = fragmentCoral.Dequeue();

                    GameObject currentCoral = Instantiate(fragmentedCoralPrefab);
                    Coral coral = currentCoral.GetComponent<Coral>();
                    coral.InitalizeOnArea(area, pos);
                    coral.GetComponentInChildren<CoralModel>().SetCoralVisual(coralData.modelIndex);
                }
                break;
        }
        return false;
    }
}
