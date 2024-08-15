using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoralStorageUI : MonoBehaviour
{
    [SerializeField] CoralStorage owner;
    [SerializeField] TMP_Text babyText;
    [SerializeField] TMP_Text juvenileText;

    private void Update() {
        UpdateUI();
    }
    private void UpdateUI() {
        babyText.text = owner.GetFragmentCount().ToString();
        juvenileText.text = owner.GetJuvenileCount().ToString();
    }
}
