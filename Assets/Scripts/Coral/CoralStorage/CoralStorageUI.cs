using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoralStorageUI : MonoBehaviour
{
    [SerializeField] CoralStorage owner;
    [SerializeField] TMP_Text text;
    private void Update() {
        UpdateUI();
    }
    private void UpdateUI() {
        text.text = "Fragmented Coral: " + owner.fragmentCoral + "\n" + "Juvenile Coral: " + owner.juvenileCoral;
    }
}
