using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralModel : MonoBehaviour {
    [SerializeField] int coralVisualIndex;
    [SerializeField] public List<GameObject> coralModels = new List<GameObject>();
    public int currentVisualIndex;
    protected GameObject currentVisual;
    private void Awake() {
        for(int i = 0; i < transform.childCount; i++) {
            coralModels.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Start() {
        if (currentVisual == null) {
            int possibleIndex = Mathf.FloorToInt(Random.value * coralModels.Count); // Setting random visual
            if (possibleIndex == coralModels.Count) { possibleIndex--; } // Dealing with edge case
            SetCoralVisual(possibleIndex);
        }
    }

    public void SetCoralVisual(int visualIndex) {
        foreach(GameObject model in coralModels) {
            model.SetActive(false);
        }
        coralModels[visualIndex].SetActive(true);
        currentVisual = coralModels[visualIndex];
        currentVisualIndex = visualIndex;
    }
}
