using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] GameObject coralPlacementDisplay;
    [SerializeField] float reach;
    [SerializeField] float coralOffsetFromSurface;
    [SerializeField] AudioSource placeCoral;
    [SerializeField] LayerMask interactable;
    CoralPlaceableArea[] areas;
    CoralStorage coralStorage;
    InteractText interactText;
    bool canInteract = true;

    private void Start() {
        coralStorage = FindObjectOfType<CoralStorage>();
        coralPlacementDisplay.SetActive(false);
        areas = FindObjectsOfType<CoralPlaceableArea>();
        interactText = FindObjectOfType<InteractText>(true);
        Debug.Log(interactText);
    }

    private void Update() {
        Ray screenToWorld = Camera.main.ScreenPointToRay(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight) / 2);

        // Interact input
        if (Input.GetMouseButtonDown(0) && canInteract) {
            InteractInput(screenToWorld);
        }

        // Display
        CoralInteractDisplay(screenToWorld);
    }

    public void SetCanInteract(bool value) {
        canInteract = value;
    }

    private void CoralInteractDisplay(Ray ray) {
        // Default value
        interactText.SetText("");
        coralPlacementDisplay.SetActive(false);

        // Raycasting
        if (Physics.Raycast(ray, out RaycastHit hit, reach, interactable)) {
            // Interacting with coral
            if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                if(coral.CanInteract()) {
                    coral.InteractHighlight();
                    interactText.SetText(coral.GetInteractText());
                }
            }

            if(hit.collider.gameObject.TryGetComponent(out Trash trash)) {
                trash.InteractHighlight();
                interactText.SetText("Pick Up");
            }

            // Checking for placeable area
            foreach (CoralPlaceableArea area in areas) {
                if (area.ContainCollider(hit.collider)) {
                    // Enable and orienting to surface
                    coralPlacementDisplay.SetActive(true);
                    Vector3 coralPlacement = hit.point - (ray.direction * coralOffsetFromSurface);
                    area.OrientCoralToSurface(coralPlacementDisplay.transform, coralPlacement);

                    // Settin gnull if there is none
                    CoralPlaceableDisplay display = coralPlacementDisplay.GetComponent<CoralPlaceableDisplay>();

                    // Setting coral type
                    switch (area.areaType) {
                        case AreaType.NURSERY:
                            if(coralStorage.GetFragmentCount() > 0) {
                                display.SetCoral(coralStorage.fragmentCoral.Peek().modelIndex, true);
                                interactText.SetText("Put Down"); // Interact UI
                            }
                            else {
                                display.SetCoral(-1, false); // setting null if there isnt any
                            }
                            break;
                        case AreaType.REEF:
                            if (coralStorage.GetJuvenileCount() > 0) {
                                display.SetCoral(coralStorage.juvenileCoral.Peek().modelIndex, false);
                                interactText.SetText("Put Down"); // Interact UI
                            }
                            else {
                                display.SetCoral(-1, false); // setting null if there isnt any
                            }
                            break;
                    }
                }
            }
        }
    }

    private void InteractInput(Ray ray) {
        if (Physics.Raycast(ray, out RaycastHit hit, reach, interactable)) {
            Debug.Log(hit.transform.gameObject.name);
            // Interacting with coral
            if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                coral.Interact();
            }

            // Putting down coral
            foreach (CoralPlaceableArea area in areas) {
                if (area.ContainCollider(hit.collider)) {
                    Vector3 coralPlacement = hit.point - (ray.direction * coralOffsetFromSurface);
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
