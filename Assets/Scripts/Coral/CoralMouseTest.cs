using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralMouseTest : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
        //InputCheck();

        if(Input.GetKeyDown(KeyCode.I)) {
            Coral[] corals = FindObjectsOfType<Coral>();

            foreach(Coral coral in corals) {
                coral.DiveStartUpdate();
            }
        }
    }
    private void InputCheck() {
        if (Input.GetMouseButton(0)) {
            Ray screenToWorld = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(screenToWorld, out RaycastHit hit)) {
                if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                    coral.Interact();
                }
                // Putting down coral
                CoralPlaceableArea[] areas = FindObjectsOfType<CoralPlaceableArea>();
                Debug.DrawLine(hit.point, hit.point + Vector3.up);
                foreach (CoralPlaceableArea area in areas) {
                    if (area.ContainCollider(hit.collider)) {
                        FindObjectOfType<CoralStorage>().TryPlaceCoral(area, hit.point);
                    }
                }
                if (hit.collider.gameObject.TryGetComponent(out PufferFish fish)) {
                    fish.ReduceOxygen();
                }
                if (hit.collider.gameObject.TryGetComponent(out Trash trash)) {
                    trash.TrashClicked();
                }
            }
        }
    }
}
