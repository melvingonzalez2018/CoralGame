using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralModel : MonoBehaviour
{
    [SerializeField] Coral owner;
    [SerializeField] float childScale;
    private void Update() {
        if(owner.IsAdult()) {
            gameObject.transform.localScale = Vector3.one;
        }
        else {
            gameObject.transform.localScale = Vector3.one * childScale;
        }
    }
}
