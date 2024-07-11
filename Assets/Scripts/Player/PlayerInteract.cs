using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float reach;
    [SerializeField] float coralOffsetFromSurface;
    CoralStorage coralStorage;

    private void Start() {
        coralStorage = FindObjectOfType<CoralStorage>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            InteractInput();
        }
    }

    private void InteractInput() {
        Ray screenToWorld = Camera.main.ScreenPointToRay(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)/2);
        if (Physics.Raycast(screenToWorld, out RaycastHit hit, reach)) {
            // Interacting with coral
            if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                coral.Interact();
            }

            // Putting down coral
            CoralPlaceableArea[] areas = FindObjectsOfType<CoralPlaceableArea>();
            //Debug.DrawLine(hit.point, hit.point + Vector3.up);
            foreach (CoralPlaceableArea area in areas) {
                if (area.ContainCollider(hit.collider)) {
                    Vector3 coralPlacement = hit.point - (screenToWorld.direction * coralOffsetFromSurface);
                    Debug.DrawLine(Camera.main.transform.position, coralPlacement, Color.blue, 3f);
                    coralStorage.TryPlaceCoral(area, coralPlacement);
                }
            }

            // Picking up trash
            if (hit.collider.gameObject.TryGetComponent(out Trash trash)) {
                trash.PickUpTrash();
            }
        }
        
    }
}
