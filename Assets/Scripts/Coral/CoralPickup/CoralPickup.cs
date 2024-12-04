using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CoralPickup : MonoBehaviour {
    [SerializeField] float attractDelay = 2f;
    [SerializeField] float initalForce = 1f;
    [SerializeField] float initalTorque = 1f;
    [SerializeField] GameObject playerContactSound;
    AttractTo attractTo;
    Rigidbody rb;
    Collider collider;
    abstract public void AddCoralToStorage(int modelIndex);

    public void InitalizeCoral(int modelIndex) {
        // Initalize other values
        GetComponent<ScaleWobble>().ActivateWobble();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        attractTo = GetComponent<AttractTo>();
        Invoke("StartAttract", attractDelay);

        // Initalizing coral model
        GetComponentInChildren<CoralModel>().SetCoralVisual(modelIndex);

        // Random upward force
        Vector2 offset = Random.insideUnitCircle.normalized;
        Vector3 direction = new Vector3(offset.x, 1, offset.y).normalized;
        rb.AddForce(direction * initalForce, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * initalTorque, ForceMode.Impulse);
    }

    public void StartAttract() {
        // Triggering attraction
        attractTo.Activate(ContactPlayer);

        // Disabling contact with terrain
        rb.useGravity = false;
        collider.isTrigger = true;
    }

    public void ContactPlayer() {
        // Transfering coral data
        int modelIndex = GetComponentInChildren<CoralModel>().currentVisualIndex;
        AddCoralToStorage(modelIndex);
        FindObjectOfType<PlayerEffectController>().ScaleWobble(); // Wobble player model

        // Create Sound effect one shot
        Instantiate(playerContactSound, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
