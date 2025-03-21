using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] GameObject coralPlacementDisplay;
    [SerializeField] float reach;
    [SerializeField] float coralOffsetFromSurface;
    [SerializeField] AudioSource placeCoral;
    [SerializeField] AudioSource garbagePickup;
    [SerializeField] LayerMask interactable;
    [SerializeField] bool minigameMode = false;
    CoralPlaceableArea[] areas;
    CoralStorage coralStorage;
    InteractText interactText;
    CoralLimitInfoText limitInfoText;
    bool canInteract = true;

    private void Start() {
        coralStorage = FindObjectOfType<CoralStorage>();
        coralPlacementDisplay.SetActive(false);
        areas = FindObjectsOfType<CoralPlaceableArea>();
        interactText = FindObjectOfType<InteractText>(true);
        limitInfoText = FindObjectOfType<CoralLimitInfoText>(true);
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
        limitInfoText.SetText("");
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
                if (trash.Interactable() && !minigameMode) {
                    trash.InteractHighlight();
                    interactText.SetText("Pick Up");
                }
            }

            // Checking for placeable area
            foreach (CoralPlaceableArea area in areas) {
                if (area.ContainCollider(hit.collider)) {
                    // Enable and orienting to surface
                    coralPlacementDisplay.SetActive(true);
                    Vector3 coralPlacement = hit.point - (ray.direction * coralOffsetFromSurface);
                    area.OrientCoralToSurface(coralPlacementDisplay.transform, coralPlacement);

                    // Setting null if there is none
                    CoralPlaceableDisplay display = coralPlacementDisplay.GetComponent<CoralPlaceableDisplay>();

                    string displayText = "";
                    // Setting coral type
                    switch (area.areaType) {
                        case AreaType.NURSERY:

                            displayText = "Nursery\nCoral Limit: ";
                            if(coralStorage.GetFragmentCount() > 0) {
                                display.SetCoral(coralStorage.fragmentCoral.Peek().modelIndex, true);
                                interactText.SetText("Put Down"); // Interact UI
                            }
                            else {
                                display.SetCoral(-1, false); // setting null if there isnt any
                            }
                            break;
                        case AreaType.REEF:
                            displayText = "Reef\nCoral Limit: ";
                            if (coralStorage.GetJuvenileCount() > 0) {
                                display.SetCoral(coralStorage.juvenileCoral.Peek().modelIndex, false);
                                interactText.SetText("Put Down"); // Interact UI
                            }
                            else {
                                display.SetCoral(-1, false); // setting null if there isnt any
                            }
                            break;
                    }

                    // Setting Interact Cursor Info
                    area.InteractHighlight();
                    if (area.limitedCoral) {
                        displayText += area.placedCoral.ToString() + "/" + area.maxCoralPlacable.ToString();
                    }
                    else {
                        displayText = "";
                    }
                    limitInfoText.SetText(displayText);
                }
            }
        }
    }

    private void InteractInput(Ray ray) {
        if (Physics.Raycast(ray, out RaycastHit hit, reach, interactable)) {
            //Debug.Log(hit.transform.gameObject.name);
            
            // Interacting with coral
            if (hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                coral.Interact();
            }

            // Putting down coral
            foreach (CoralPlaceableArea area in areas) {
                if (area.ContainCollider(hit.collider)) {
                    Vector3 coralPlacement = hit.point - (ray.direction * coralOffsetFromSurface);
                    if(coralStorage.TryPlaceCoral(area, coralPlacement)) {
                        placeCoral.Stop();
                        placeCoral.Play();
                    }
                }
            }

            // Picking up trash
            if (hit.collider.gameObject.TryGetComponent(out Trash trash)) {
                garbagePickup.Stop();
                garbagePickup.Play();
                trash.TrashClicked();
            }
        }
    }
}
