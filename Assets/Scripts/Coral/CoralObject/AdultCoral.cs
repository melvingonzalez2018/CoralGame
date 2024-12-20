using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultCoral : Coral
{
    [SerializeField] AudioSource harvestSource;
    [SerializeField] GameObject fragmentPickup;
    bool fragmentAvailable = true;

    public bool GetFragmentAvailable() {
        return fragmentAvailable;
    }

    public override void Interact() {
        if (fragmentAvailable) {
            // Audio
            harvestSource.Play();

            // Creating pickup
            GameObject coralPickupInstance = Instantiate(fragmentPickup, transform.position, transform.rotation);
            int modelIndex = GetComponentInChildren<CoralModel>().currentVisualIndex;

            // Initalizing Pickup
            FragmentCoralPickup pickup = coralPickupInstance.GetComponent<FragmentCoralPickup>();
            pickup.InitalizeCoral(modelIndex);
            pickup.AttractToPlayer();

            // Juice
            GetComponent<ScaleWobble>().ActivateWobble();

            // Adjusting variables
            fragmentAvailable = false;
            bubbleBurst.Play();
        }
    }

    public override void DiveStartUpdate() {
        if(!fragmentAvailable) {
            fragmentAvailable = true;
        }
    }

    public override bool CanInteract() {
        return fragmentAvailable;
    }

    public override string GetInteractText() {
        return "Break Fragment";
    }
}
