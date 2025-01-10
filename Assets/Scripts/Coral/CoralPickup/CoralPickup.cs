using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CoralPickup : MonoBehaviour {
    [SerializeField] float attractDelay = 2f;
    [SerializeField] float initalForce = 1f;
    [SerializeField] float initalTorque = 1f;
    [SerializeField] GameObject playerContactSound;
    ParticleSystem bubbleBurst;
    AttractTo attractTo;
    Rigidbody rb;
    Collider collider;
    GameObject placementTarget;
    abstract public void AddCoralToStorage(int modelIndex);
    abstract public void PlaceCoral(int modelIndex, CoralPlaceableArea area, Vector3 pos);


    public void InitalizeCoral(int modelIndex) {
        // Initalize other values
        GetComponent<ScaleWobble>().ActivateWobble();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        attractTo = GetComponent<AttractTo>();
        bubbleBurst = GetComponentInChildren<ParticleSystem>();
        bubbleBurst.Play();

        // Initalizing coral model
        GetComponentInChildren<CoralModel>().SetCoralVisual(modelIndex);

        // Random upward force
        Vector2 offset = Random.insideUnitCircle.normalized;
        Vector3 direction = new Vector3(offset.x, 1, offset.y).normalized;
        rb.AddForce(direction * initalForce, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * initalTorque, ForceMode.Impulse);
    }

    public void AttractToPlayer() {
        Invoke("StartAttractToPlayer", attractDelay);
    }
    public void AttractToPlacement(int modelIndex, GameObject target) {
        placementTarget = target;
        FindObjectOfType<PlayerEffectController>().ScaleWobble(); // Wobble player model
        Invoke("StartAttractToPlacement", attractDelay);
    }

    public void StartAttractToPlayer() {
        // Triggering attraction
        attractTo.Activate(FindAnyObjectByType<PlayerMovementController>().gameObject, ContactPlayer);
        rb.angularVelocity = Vector3.zero;

        // Disabling contact with terrain
        rb.useGravity = false;
        collider.isTrigger = true;
    }

    public void StartAttractToPlacement() {
        // Triggering attraction
        attractTo.Activate(placementTarget, ContactPlacement);
        rb.angularVelocity = Vector3.zero;

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

    public void ContactPlacement() {
        // Transfering coral data
        int modelIndex = GetComponentInChildren<CoralModel>().currentVisualIndex;
        CoralPutDownTarget putDownTarget = placementTarget.GetComponent<CoralPutDownTarget>();
        PlaceCoral(modelIndex, putDownTarget.GetArea(), putDownTarget.transform.position);

        // Create Sound effect one shot
        Instantiate(playerContactSound, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(placementTarget);
    }
}
