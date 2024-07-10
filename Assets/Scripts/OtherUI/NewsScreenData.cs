using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewsScreenData", order = 1)]
public class NewsScreenData : ScriptableObject {
    [SerializeField] public string headlineText;
    [SerializeField] public string date;
    [SerializeField] [TextArea] public string bossText;
}