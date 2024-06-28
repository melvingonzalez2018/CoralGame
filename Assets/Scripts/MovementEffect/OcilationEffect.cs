using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcilationEffect : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float frequencyScale;
    [SerializeField] Vector3 direction;
    float timer = 0;
    Vector3 initalPos;
    private void Start() {
        initalPos = transform.position;
    }

    private void Update() {
        timer += Time.deltaTime * frequencyScale;
        timer = timer % (Mathf.Deg2Rad * 360f); // Limiting timer
        transform.position = initalPos + (Mathf.Sin(timer)*direction.normalized*amplitude);
    }
}
