using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenDiveSelector : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    Color initialColor;
    public Color slectedTextColor;
    private void Start() {
        initialColor = buttons[0].GetComponent<Image>().color;
    }
    public void UpdateInteractableButtons(int buttonDiveNumber) {
        for(int i = 0; i < buttons.Count; i++) {
            if (i <= buttonDiveNumber) {
                buttons[i].GetComponent<Button>().interactable = true;
            }
            else {
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ButtonPress(int buttonDiveNumber) {
        foreach(GameObject button in buttons) {
            button.GetComponent<Image>().color = initialColor;
            button.GetComponentInChildren<TMP_Text>().color = Color.white;
        }

        buttons[buttonDiveNumber].GetComponent<Image>().color = Color.white;
        buttons[buttonDiveNumber].GetComponentInChildren<TMP_Text>().color = slectedTextColor;
    }
}
