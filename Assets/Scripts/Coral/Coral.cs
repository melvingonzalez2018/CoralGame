using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coral : MonoBehaviour {
    [SerializeField] CoralPlaceableArea area = null; // Area, set this as the intial area for the coral
    [SerializeField] public float timeForAdult; // Time it takes for the coral to mature
    [SerializeField] public float ageTimer = 0f; // Inital age of the coral, if you want an adult just set it over the limit set above
    [SerializeField] public float pickUpTime; // time it takes to pick up coral
    [HideInInspector] public float pickUpTimer = 0;
    [SerializeField] public float hammerTime;
    [HideInInspector] public float hammerTimer = 0;

    private void Start() {
        // Orient any coral to the current place
        if(area != null) {
            area.OrientCoralToSurface(transform, transform.position);
            if(IsAdult()) {
                hammerTimer = hammerTime;
            }
        }
    }
    private void Update() {
        AgeUpdate();
    }

    public void Interact() {
        if (area != null) {
            switch (area.areaType) {
                case AreaType.NURSERY:
                    if(IsAdult()) {
                        PickUpUpdate();
                    }
                    break;
                case AreaType.REEF:
                    if(IsAdult()) {
                        HammerUpdate();
                    }
                    else {
                        PickUpUpdate();
                    }
                    break;
                case AreaType.NULL:
                    PickUpUpdate();
                    break;
            }
        }
    }

    private void HammerUpdate() {
        if(!IsHammeredIn()) {
            hammerTimer += Time.deltaTime;
            if(IsHammeredIn()) {
                FindObjectOfType<StatTracking>().IterateCoralHammered();
            }
        }
    }

    // To be run every update to increment the timer
    private void PickUpUpdate() {
        pickUpTimer += Time.deltaTime;
        if (pickUpTimer >= pickUpTime) {
            PickUp();
            pickUpTimer = 0;
        }
    }
    public bool IsGrowing() {
        return !IsAdult() && area.areaType == AreaType.NURSERY;
    }
    public bool IsPlaced() {
        if(area != null) {
            if(area.areaType == AreaType.REEF && IsHammeredIn()) {
                return true;
            }
            else if(area.areaType == AreaType.NURSERY) {
                return true;
            }
        }

        return false;
    }
    public bool IsHammeredIn() {
        return hammerTimer >= hammerTime;
    }
    public bool IsAdult() {
        return ageTimer >= timeForAdult;
    }
    private void AgeUpdate() {
        // Age coral if its in the nursery
        if (area.areaType == AreaType.NURSERY && !IsAdult()) {
            ageTimer += Time.deltaTime;
            if(IsAdult()) {
                FindObjectOfType<StatTracking>().IterateCoralGrown();
            }
        }
    }
    public void PickUp() {
        FindObjectOfType<StatTracking>().IterateCoralPickup();
        FindAnyObjectByType<CoralStorage>().AddCoral(this);
        gameObject.SetActive(false);
    }
    public bool TryPutDown(CoralPlaceableArea newArea, Vector3 pos) {
        if (newArea.OrientCoralToSurface(transform, pos)) {
            gameObject.SetActive(true);
            area = newArea;
            return true;
        }
        return false;
    }
}
