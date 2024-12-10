using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoralLimitInfoText : MonoBehaviour {
    [SerializeField] TMP_Text text;
    private void Start() {
        text = GetComponent<TMP_Text>();
    }
    public void SetText(string inputText) {
        text.text = inputText;
    }
}
