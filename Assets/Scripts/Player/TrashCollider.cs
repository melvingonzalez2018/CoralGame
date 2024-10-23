using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollider : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent(out Trash trash)) {
            trash.PickUpTrash();
        }
    }
}
