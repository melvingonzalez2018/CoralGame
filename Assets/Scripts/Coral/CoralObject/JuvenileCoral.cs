using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuvenileCoral : Coral {
    [SerializeField] AudioSource hammerAudio;
    [SerializeField] GameObject takeCoralOneShot;
    [SerializeField] GameObject adultCoralPrefab;
    [SerializeField] GameObject coralPickup;
    [SerializeField] public float hammerTime;
    [SerializeField] float hammerPerClick;
    [HideInInspector] public float hammerTimer = 0;
    [SerializeField] float maxHammerAngleOffset = 1f;
    bool canInteract = true;
    Vector3 offsetUp = Vector3.zero;


    override protected void MyStart() {
        if(IsOnReef() && !IsHammeredIn()) {
            InitalizeRandomUp();
        }
    }

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

            GameObject currentCoral = Instantiate(adultCoralPrefab, transform.position, transform.rotation);
            currentCoral.GetComponentInChildren<CoralModel>().SetCoralVisual(GetComponentInChildren<CoralModel>().currentVisualIndex); // Setting coral visual
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
            GetComponent<ScaleWobble>().ActivateWobble();

            // Calculating and applying hammered up
            float percent = hammerTimer / hammerTime;
            transform.up = Vector3.Lerp(offsetUp, upDirectionOnSurface, percent);

            hammerTimer += hammerPerClick;
            hammerAudio.Stop();
            hammerAudio.Play();
            if (IsHammeredIn()) {
                transform.up = upDirectionOnSurface;
                FindObjectOfType<StatTracking>().IterateCoralHammered();
                bubbleBurst.Play();
            }
        }
    }

    private void InitalizeRandomUp() {
        // Initalizing a random up direction for hammering
        Vector2 randomUnit = Random.insideUnitCircle.normalized * maxHammerAngleOffset;
        Vector3 offset = Quaternion.FromToRotation(Vector3.up, upDirectionOnSurface.normalized) * new Vector3(randomUnit.x, 0, randomUnit.y);
        Vector3 randomUp = (upDirectionOnSurface.normalized + offset).normalized;
        offsetUp = randomUp;
        transform.up = offsetUp;
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

        // Initalizing Pickup
        JuvenileCoralPickup pickup = coralPickupInstance.GetComponent<JuvenileCoralPickup>();
        pickup.InitalizeCoral(modelIndex);
        pickup.AttractToPlayer();

        // Reducing area amount 
        area.MinusCoralCount();

        // Setting up Attraction
        canInteract = false;
        Destroy(gameObject);
    }
}