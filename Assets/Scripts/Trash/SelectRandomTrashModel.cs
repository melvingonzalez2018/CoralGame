using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomTrashModel : MonoBehaviour
{
    List<GameObject> trashModels = new List<GameObject>();
    int currentActiveIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++) {
            trashModels.Add(transform.GetChild(i).gameObject);
        }

        int index = Mathf.FloorToInt(Random.value * trashModels.Count);
        if (index == trashModels.Count) { index--; }
        SetModelIndex(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetModelIndex(int index) {
        foreach(GameObject model in trashModels) {
            model.SetActive(false);
        }
        trashModels[index].SetActive(true);
        currentActiveIndex = index;
    } 
}
