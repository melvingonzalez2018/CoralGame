using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeDisplayManager : MonoBehaviour
{
    Queue<string> upgradeToDisplay = new Queue<string>();
    [SerializeField] float displayDelay;
    [SerializeField] GameObject upgradeTextDisplay;

    // Start is called before the first frame update
    void Start() {
        Invoke("CreateTextUpdate", displayDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddUpgradeText(string text) {
        upgradeToDisplay.Enqueue(text);
    }
    private void CreateUpgradeText(string text) {
        GameObject textObj = Instantiate(upgradeTextDisplay, transform);
        textObj.GetComponent<TMP_Text>().text = text;
    }

    private void CreateTextUpdate() {
        if(upgradeToDisplay.Count > 0 && isActiveAndEnabled) {
            CreateUpgradeText(upgradeToDisplay.Peek());
            upgradeToDisplay.Dequeue();
        }

        Invoke("CreateTextUpdate", displayDelay);
    }
}
