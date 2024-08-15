using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearFollowPath : MonoBehaviour
{
    [SerializeField] FollowPath path;
    [SerializeField] float reachPointDist; // The distance away from the next point 
    [SerializeField] float speed; // How fast the object moves
    [SerializeField] [Range(0f,1f)] float rotationMag;
    Transform nextPoint;
    int pathIndex = 0;
    bool isFollowing = true;
    private void Start() {
        UpdateNextPoint();
    }

    private void Update() {
        if (nextPoint != null && isFollowing) {
            MoveUpdate();
        }
    }

    public void SetIsFollow(bool value) {
        isFollowing = value;
    }

    private void MoveUpdate() {
        Vector3 difference = nextPoint.position - transform.position;
        if(difference.magnitude <= reachPointDist) {
            UpdateNextPoint();
        }
        else {
            transform.forward = Vector3.Lerp(transform.forward, difference.normalized, rotationMag); // Face target
            transform.position += speed * difference.normalized * Time.deltaTime; // move to target
        }
    }
    private void UpdateNextPoint() {
        if (path != null) {
            nextPoint = path.GetPathPoint(pathIndex);
            pathIndex++;
        }
    }
}
