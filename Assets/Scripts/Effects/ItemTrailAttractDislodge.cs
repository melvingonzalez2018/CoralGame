using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrailAttractDislodge : MonoBehaviour
{
    [SerializeField] AttractTo attractTo = null;

    private void Start() {
        AttractTo holder;
        if(transform.parent.TryGetComponent<AttractTo>(out holder)) {
            attractTo = holder;
        }
        if(attractTo) {
            attractTo.OnCompleteEffect.AddListener(Dislodge);
        }
    }

    public void Dislodge() {
        transform.parent = null;
    }
}
