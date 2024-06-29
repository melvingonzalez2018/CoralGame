using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float reach;

    private void Update() {
        if (Input.GetMouseButton(0)) {
            InteractInput();
        }
    }

    private void InteractInput() {
        Ray screenToWorld = Camera.main.ScreenPointToRay(Vector2.one/2);
        if (Physics.Raycast(screenToWorld, out RaycastHit hit, reach)) {
            // Interacting with coral
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

            // Picking up trash
            if (hit.collider.gameObject.TryGetComponent(out Trash trash)) {
                trash.PickUpTrash();
            }
        }
        
    }
}
