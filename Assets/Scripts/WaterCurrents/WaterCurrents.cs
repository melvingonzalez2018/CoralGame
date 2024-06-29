using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCurrents : MonoBehaviour
{
    [SerializeField] Transform currentDirection;
    [SerializeField] float currentForce;
    [SerializeField] string playerTag;
    private void OnTriggerStay(Collider other) {
        if(other.tag == playerTag) {
            other.GetComponent<Rigidbody>().velocity += currentForce * currentDirection.forward * Time.deltaTime;
        }
    }
}
