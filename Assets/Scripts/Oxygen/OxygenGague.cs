using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenGague : MonoBehaviour
{
    [SerializeField] Oxygen owner;
    [SerializeField] Slider slider;

    private void Update() {
        slider.value = 1-(owner.timer / owner.oxygenDuration);
    }
}
