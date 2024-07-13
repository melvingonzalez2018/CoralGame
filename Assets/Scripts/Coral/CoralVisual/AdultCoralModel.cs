using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultCoralModel : CoralModel
{
    [SerializeField] AdultCoral owner;

    // Update is called once per frame
    void Update() {
        if(currentVisual != null) {
            VisualUpdate();
        }
    }

    public void VisualUpdate() {
        if (owner.GetFragmentAvailable()) {
            // Setting regular adult
            currentVisual.transform.GetChild(0).gameObject.SetActive(true);
            currentVisual.transform.GetChild(1).gameObject.SetActive(false);
        }
        else {
            // Setting fragemented adult
            currentVisual.transform.GetChild(0).gameObject.SetActive(false);
            currentVisual.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
