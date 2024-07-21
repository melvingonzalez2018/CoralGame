using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralPlaceableDisplay : MonoBehaviour {
    [SerializeField] GameObject juvenile;
    [SerializeField] GameObject fragmented;
    [SerializeField] GameObject neutral;
    
    public void SetCoral(int index, bool isFragmented) {
        if(index < 0) {
            juvenile.SetActive(false);
            fragmented.SetActive(false);
            neutral.SetActive(true);
            return;
        }

        // Setting normal
        neutral.SetActive(false);
        if (isFragmented) {
            juvenile.SetActive(false);
            fragmented.SetActive(true);
            // Disable all models
            for(int i = 0; i < fragmented.transform.childCount; i++) {
                fragmented.transform.GetChild(i).gameObject.SetActive(false);
            }

            fragmented.transform.GetChild(index).gameObject.SetActive(true);
        }
        else {
            fragmented.SetActive(false);
            juvenile.SetActive(true);
            // Disable all models
            for (int i = 0; i < juvenile.transform.childCount; i++) {
                juvenile.transform.GetChild(i).gameObject.SetActive(false);
            }

            juvenile.transform.GetChild(index).gameObject.SetActive(true);
        }
    }
}
