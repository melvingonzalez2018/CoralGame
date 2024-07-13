using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralModel : MonoBehaviour {
    [SerializeField] int coralVisualIndex;
    [SerializeField] List<GameObject> coralModel;
    public int currentVisualIndex;
    protected GameObject currentVisual;
    private void Awake() {
        if(currentVisual == null) {
            SetCoralVisual(Mathf.FloorToInt(Random.value * coralModel.Count));
        }
    }

    public void SetCoralVisual(int visualIndex) {
        foreach(GameObject model in coralModel) {
            model.SetActive(false);
        }
        coralModel[visualIndex].SetActive(true);
        currentVisual = coralModel[visualIndex];
        currentVisualIndex = visualIndex;
    }
}
