using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralMouseTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Ray screenToWorld = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(screenToWorld, out RaycastHit hit)) {
                if(hit.collider.gameObject.TryGetComponent(out Coral coral)) {
                    coral.Interact();
                }
                // Putting down coral
                CoralPlaceableArea[] areas = FindObjectsOfType<CoralPlaceableArea>();
                foreach (CoralPlaceableArea area in areas) {
                    if (area.ContainCollider(hit.collider)) {
                        FindObjectOfType<CoralStorage>().TryPlaceCoral(area, hit.point);
                    }
                }
            }
        }
    }
}