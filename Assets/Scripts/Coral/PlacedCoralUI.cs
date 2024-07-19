using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlacedCoralUI : MonoBehaviour
{
    [SerializeField] CoralPlaceableArea owner;
    [SerializeField] TMP_Text coralCount;

    // Update is called once per frame
    void Update()
    {
        if (owner.limitedCoral) {
            coralCount.text = owner.placedCoral + "/" + owner.maxCoralPlacable;
        }
        else {
            coralCount.text = "";
        }
    }
}
