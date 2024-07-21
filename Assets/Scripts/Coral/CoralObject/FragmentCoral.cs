using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCoral : Coral {
    [SerializeField] GameObject juvenileCoralPrefab;
    public override void Interact() {
        // Do nothing
    }

    public override void DiveStartUpdate() {
        GameObject currentCoral = Instantiate(juvenileCoralPrefab, transform.position, Quaternion.identity);
        //currentCoral.GetComponent<Coral>().InitalizeOnArea(area, transform.position); // Setting area
        area.MinusCoralCount();
        Destroy(gameObject);
    }

    public override bool CanInteract() {
        return false;
    }
}
