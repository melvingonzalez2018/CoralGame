using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float reach;
    [SerializeField] float coralOffsetFromSurface;
    [SerializeField] AudioSource placeCoral;
    CoralStorage coralStorage;
    bool canInteract = true;

    private void Start() {
        coralStorage = FindObjectOfType<CoralStorage>();
    }

    private void Update() {
        Ray screenToWorld = Camera.main.ScreenPointToRay(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight) / 2);

        // Interact input
        if (Input.GetMouseButtonDown(0) && canInteract) {
            InteractInput(screenToWorld);
        }

        // Highlight
        HighlightCoral(screenToWorld);
    }

    public void SetCanInteract(bool value) {
        canInteract = value;
    }

    private void HighlightCoral(Ray ray) {
        if (Physics.Raycast(ray, out RaycastHit hit, reach)) {
            // Interacting with coral
            if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                if(coral.CanInteract()) {
                    coral.InteractHighlight();
                }
            }
        }
    }

    private void InteractInput(Ray ray) {
        if (Physics.Raycast(ray, out RaycastHit hit, reach)) {
            // Interacting with coral
            if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                coral.Interact();
            }

            // Putting down coral
            CoralPlaceableArea[] areas = FindObjectsOfType<CoralPlaceableArea>();
            //Debug.DrawLine(hit.point, hit.point + Vector3.up);
            foreach (CoralPlaceableArea area in areas) {
                if (area.ContainCollider(hit.collider)) {
                    Vector3 coralPlacement = hit.point - (ray.direction * coralOffsetFromSurface);
                    Debug.DrawLine(Camera.main.transform.position, coralPlacement, Color.blue, 3f);
                    if(coralStorage.TryPlaceCoral(area, coralPlacement)) {
                        placeCoral.Play();
                    }
                }
            }

            // Picking up trash
            if (hit.collider.gameObject.TryGetComponent(out Trash trash)) {
                trash.PickUpTrash();
            }
        }
    }
}
