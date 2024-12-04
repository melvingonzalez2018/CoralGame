using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuvenileCoral : Coral {
    [SerializeField] AudioSource hammerAudio;
    [SerializeField] GameObject takeCoralOneShot;
    [SerializeField] GameObject adultCoralPrefab;
    [SerializeField] GameObject coralPickup;
    [SerializeField] public float hammerTime;
    [SerializeField] float hammerPerClick;
    [HideInInspector] public float hammerTimer = 0;
    bool canInteract = true;

    public override void Interact() {
        if (area != null) {
            switch (area.areaType) {
                case AreaType.NURSERY:
                    PickUp();
                    break;
                case AreaType.REEF:
                    HammerUpdate();
                    break;
                case AreaType.NULL:
                    PickUp();
                    break;
            }
        }
    }

    public override void DiveStartUpdate() {
        if(IsOnReef() && IsHammeredIn()) {
            FindObjectOfType<StatTracking>().IterateCoralGrown();

            GameObject currentCoral = Instantiate(adultCoralPrefab, transform.position, Quaternion.identity);
            //currentCoral.GetComponent<Coral>().InitalizeOnArea(area, transform.position); // Setting area
            area.MinusCoralCount();
            Destroy(gameObject);
        }
    }

    public override bool CanInteract() {
        if(!canInteract) {
            return false;
        }
        if(area.areaType == AreaType.NURSERY) {
            return true;
        }
        if(area.areaType == AreaType.REEF && !IsHammeredIn()) {
            return true;
        }
        return false;
    }

    public override string GetInteractText() {
        if (area.areaType == AreaType.NURSERY) {
            return "Pick Up";
        }
        if (area.areaType == AreaType.REEF && !IsHammeredIn()) {
            return "Hammer In";
        }
        return "No Interact";
    }

    private void HammerUpdate() {
        if (!IsHammeredIn()) {
            hammerTimer += hammerPerClick;
            hammerAudio.Stop();
            hammerAudio.Play();
            if (IsHammeredIn()) {
                FindObjectOfType<StatTracking>().IterateCoralHammered();
            }
        }
    }

    public void FullyHammerIn() {
        hammerTimer = hammerTime;
    }

    public bool IsOnReef() {
        Debug.Assert(area != null);
        return area.areaType == AreaType.REEF;
    }

    public bool IsHammeredIn() {
        return hammerTimer >= hammerTime;
    }

    public void PickUp() {
        // Playing audio
        Instantiate(takeCoralOneShot, transform.position, Quaternion.identity); // Playing pickup audio

        // Setting up coral pickup
        GameObject coralPickupInstance = Instantiate(coralPickup, transform.position, transform.rotation); // Playing pickup audio
        int modelIndex = GetComponentInChildren<CoralModel>().currentVisualIndex;
        coralPickupInstance.GetComponent<JuvenileCoralPickup>().InitalizeCoral(modelIndex);

        // Reducing area amount 
        area.MinusCoralCount();

        // Setting up Attraction
        canInteract = false;
        Destroy(gameObject);
    }
}