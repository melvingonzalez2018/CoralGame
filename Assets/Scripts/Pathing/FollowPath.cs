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
            Gizmos.color = Color.Lerp(Color.blue, Color.red, (float)i / points.Count);
            Gizmos.DrawWireSphere(points[i].position, 0.1f);
        }
    }
    private void GetPoints() {
        points = new List<Transform>(GetComponentsInChildren<Transform>());
        points.Remove(transform);
        Debug.Log(points.Count);
    }
}