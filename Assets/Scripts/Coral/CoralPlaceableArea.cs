using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AreaType {
    REEF,
    NURSERY,
    NULL
}

public class CoralPlaceableArea : MonoBehaviour
{
    [SerializeField] public AreaType areaType = AreaType.NULL;
    [SerializeField] float surfaceCheckOffset;
    [SerializeField] public int maxCoralPlacable;
    [SerializeField] public bool limitedCoral = true;
    [HideInInspector] public int placedCoral = 0;

    List<Collider> placeableSurfaces = new List<Collider>();
    Collider areaCollider;
    private void Awake() {
        foreach (Collider childCollider in transform.GetComponentsInChildren<Collider>()) {
            placeableSurfaces.Add(childCollider);
        }
    }

    private bool UseOverlapCollider() {
        return areaCollider != null;
    }

    public bool ContainCollider(Collider check) {
        foreach (Collider surface in placeableSurfaces) {
            if(surface == check) {
                return true;
            }
        }
        return false;
    }

    // Orients the given transform to the surface of the listed colliders, returns true if the orientation was successful
    public bool OrientCoralToSurface(Transform coral, Vector3 pos) {
        // Orienting transform
        if(FindClosestPoint(pos, out RaycastHit hit)) {
            coral.position = hit.point;
            coral.up = hit.normal;
            return true;
        }

        return false;
    }

    // Return true if you found a valid point false otherwise
    public bool FindClosestPoint(Vector3 pos, out RaycastHit hit) {
        hit = new RaycastHit();
        float distToClosest = float.MaxValue;

        foreach (Collider surface in placeableSurfaces) {
            Vector3 pointOnSurface = surface.ClosestPoint(pos);

            if(pointOnSurface == pos) {
                pos -= (surface.gameObject.transform.position - pos)*surfaceCheckOffset;
            }
            
            Vector3 dirToSurface = pointOnSurface - pos;
            surface.Raycast(new Ray(pos, dirToSurface), out RaycastHit hitSurface, float.MaxValue);

            // Checking if within bounds
            if (UseOverlapCollider()) {
                if (!areaCollider.bounds.Contains(pointOnSurface)) {
                    continue;
                }
            }

            // Checking closest collider
            float checkClosest = (pos - pointOnSurface).magnitude;
            if (checkClosest < distToClosest) {
                hit = hitSurface;
                distToClosest = checkClosest;
            }
        }

        return distToClosest != float.MaxValue;
    }

    // Checks if a position is a valid position to place coral
    public bool PositionWithinBounds(Vector3 pos) {
        if (UseOverlapCollider()) {
            foreach (Collider surface in placeableSurfaces) {
                Vector3 pointOnSurface = surface.ClosestPoint(pos);

                // Checking if within bounds
                if (areaCollider.bounds.Contains(pointOnSurface)) {
                    return true;
                }
            }
            return false;
        }
        return true;
    }

    public void AddCoralCount() {
        placedCoral++;
    }
    public void MinusCoralCount() {
        placedCoral--;
    }

    public bool CanPlaceCoral() {
        if(!limitedCoral) {
            return true;
        }

        return placedCoral < maxCoralPlacable;
    }
}
