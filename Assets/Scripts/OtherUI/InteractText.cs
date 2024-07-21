using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractText : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void SetText(string inputText) {
        text.text = inputText;
    }
}
