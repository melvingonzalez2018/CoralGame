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
        if(FindClosestPoint(pos, out Vector3 closestPoint)) {
            Vector3 dirToSurface = closestPoint - pos;
            coral.up = -dirToSurface.normalized;
            coral.position = closestPoint;
            return true;
        }

        return false;
    }

    // Return true if you found a valid point false otherwise
    public bool FindClosestPoint(Vector3 pos, out Vector3 closestPoint) {
        closestPoint = Vector3.zero;
        float distToClosest = float.MaxValue;

        foreach (Collider surface in placeableSurfaces) {
            Vector3 pointOnSurface = surface.ClosestPoint(pos);

            // Checking if within bounds
            if (UseOverlapCollider()) {
                if (!areaCollider.bounds.Contains(pointOnSurface)) {
                    continue;
                }
            }

            // Checking closest collider
            float checkClosest = (pos - pointOnSurface).magnitude;
            if (checkClosest < distToClosest) {
                closestPoint = pointOnSurface;
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
}
