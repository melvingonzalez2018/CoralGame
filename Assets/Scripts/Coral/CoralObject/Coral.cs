using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coral : MonoBehaviour {
    [SerializeField] AreaType defaultStick;
    [SerializeField] protected CoralPlaceableArea area = null; // Area, set this as the intial area for the coral

    public abstract void Interact();
    public abstract void DiveStartUpdate();

    private void Start() {
        SetAreaUpdate();
    }

    private void SetAreaUpdate() {
        // Orient any coral to the current place
        if (area != null) {
            area.OrientCoralToSurface(transform, transform.position);
        }
        else {
            SetClosestPlaceable();
        }
    }
    //public static GameObject InstantiateCoral(GameObject prefab, CoralPlaceableArea area, Vector3 pos) {

    //}

    private void SetClosestPlaceable() {
        CoralPlaceableArea closestPlaceableArea = null;
        float lowestDistToPoint = float.MaxValue;

        // Finding closest valid placeable
        foreach(CoralPlaceableArea placeableArea in FindObjectsOfType<CoralPlaceableArea>()) {
            if(placeableArea.areaType == defaultStick) { // Checking default stick
                if(placeableArea.FindClosestPoint(transform.position, out RaycastHit hit)) { // Checking distance
                    float currentDistToPoint = (hit.point - transform.position).magnitude;
                    if (lowestDistToPoint > currentDistToPoint) {
                        lowestDistToPoint = currentDistToPoint;
                        closestPlaceableArea = placeableArea;
                    }
                }
            }
        }

        InitalizeOnArea(closestPlaceableArea, transform.position); // Setting area and setting
    }

    public void InitalizeOnArea(CoralPlaceableArea newArea, Vector3 pos) {
        if (newArea.OrientCoralToSurface(transform, pos)) {
            area = newArea;
        }
    }
    public void SetArea(CoralPlaceableArea newArea) {
        area = newArea;
    }
}