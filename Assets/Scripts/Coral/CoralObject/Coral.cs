using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coral : MonoBehaviour {
    [SerializeField] protected CoralPlaceableArea area = null; // Area, set this as the intial area for the coral

    public abstract void Interact();
    public abstract void DiveStartUpdate();

    private void Start() {
        // Orient any coral to the current place
        if(area != null) {
            area.OrientCoralToSurface(transform, transform.position);
        }
    }

    public bool InitalizeOnArea(CoralPlaceableArea newArea, Vector3 pos) {
        if (newArea.OrientCoralToSurface(transform, pos)) {
            gameObject.SetActive(true);
            area = newArea;
            return true;
        }
        return false;
    }
}
