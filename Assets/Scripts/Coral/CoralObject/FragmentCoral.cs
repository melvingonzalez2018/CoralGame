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
        Debug.Log("AFter fragment instantiate");
        //currentCoral.GetComponent<Coral>().SetArea(area);
        //currentCoral.transform.forward = transform.forward; // Setting orientation
        //currentCoral.GetComponent<Coral>().InitalizeOnArea(area, transform.position); // Setting area
        Destroy(gameObject);
    }
}
