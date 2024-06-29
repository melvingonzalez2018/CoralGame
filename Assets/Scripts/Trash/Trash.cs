using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {
    public void PickUpTrash() {
        FindObjectOfType<StatTracking>().IterateTrashCollected();
        Destroy(gameObject);
    }
}
