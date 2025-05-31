using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCoral : Coral {
    [SerializeField] GameObject juvenileCoralPrefab;
    public override void Interact() {
        // Do nothing
    }

    public override void DiveStartUpdate() {
        GameObject currentCoral = Instantiate(juvenileCoralPrefab, transform.position, transform.rotation);
        currentCoral.GetComponentInChildren<CoralModel>().SetCoralVisual(GetComponentInChildren<CoralModel>().currentVisualIndex); // Setting coral visual
        area.MinusCoralCount();
        Destroy(gameObject);
    }

    public override bool CanInteract() {
        return false;
    }
    public override string GetInteractText() {
        return "No Interact";
    }
}
