using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] bool loop = true;
    List<Transform> points = new List<Transform>();
    private void Awake() {
        GetPoints();
    }

    public Vector3 GetCenterOfPath() {
        Vector3 sum = Vector3.zero;
        foreach(Transform point in points) {
            sum += point.position;
        }
        return sum / points.Count;
    }

    public Transform GetPathPoint(int index) {
        if (index < points.Count) {
            return points[index];
        }
        else if(loop) {
            return points[index % points.Count];
        }
        return null;
    }

    private void OnDrawGizmos() {
        GetPoints();
        for (int i = 0; i < points.Count; i++) {
            Gizmos.color = Color.Lerp(Color.blue, Color.red, (float)i / (points.Count-1));
            //Gizmos.DrawWireSphere(points[i].position, 0.1f);
            Gizmos.DrawLine(points[i].position, points[(i + 1)%points.Count].position);
        }
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(GetCenterOfPath(), 0.25f); // Marking center of path
    }
    private void GetPoints() {
        points = new List<Transform>(GetComponentsInChildren<Transform>());
        points.Remove(transform);
    }
}