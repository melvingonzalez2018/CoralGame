using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coral : MonoBehaviour {
    [SerializeField] AreaType defaultStick;
    [SerializeField] protected CoralPlaceableArea area = null; // Area, set this as the intial area for the coral
    protected Vector3 upDirectionOnSurface = Vector3.zero;
    float highlightTimer;
    Outline outline;
    
    public abstract void Interact();
    public abstract void DiveStartUpdate();
    public abstract bool CanInteract();
    public abstract string GetInteractText();

    virtual protected void MyStart() { }

    private void Start() {
        SetAreaUpdate();
        outline = GetComponent<Outline>();

        if(TryGetComponent<ScaleWobble>(out ScaleWobble wobble)) {
            wobble.ActivateWobble();
        }
        MyStart();
    }

    private void LateUpdate() {
        highlightTimer -= Time.deltaTime;
        if (highlightTimer < 0) {
            outline.enabled = false;
        }
    }

    public void InteractHighlight() {
        highlightTimer = Time.deltaTime;
        outline.enabled = true;
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
            if(area != null) {
                area.MinusCoralCount();
            }
            area = newArea;
            area.AddCoralCount();
            upDirectionOnSurface = transform.up;
        }
    }
}
