using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NewsScreen : MonoBehaviour {
    [SerializeField] DiveManager diveManager;
    [SerializeField] TMP_Text headlineText;
    [SerializeField] TMP_Text dateText;
    [SerializeField] TMP_Text bossText;
    [SerializeField] List<NewsScreenData> screenDatas = new List<NewsScreenData>();

    private void Start() {
        foreach(UnityEvent startEvent in diveManager.OnStartDiveEvents) {
            startEvent.AddListener(UpdateText);
        }
    }

    public void UpdateText() {
        int currentDive = diveManager.GetCurrentDive();
        if(currentDive <= screenDatas.Count) {
            headlineText.text = screenDatas[currentDive].headlineText;
            dateText.text = screenDatas[currentDive].date;
            bossText.text = screenDatas[currentDive].bossText;
        }
    }
}
