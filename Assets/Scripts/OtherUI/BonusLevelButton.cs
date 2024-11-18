using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusLevelButton : MonoBehaviour
{
    [SerializeField] Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = PlayerPrefs.GetInt("UnlockedBonusLevel", 0) == 1;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.B)) {
            PlayerPrefs.SetInt("UnlockedBonusLevel", 0);
        }
    }
}
