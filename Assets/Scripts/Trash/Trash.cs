using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {
    [SerializeField] float attractDelay = 2f;
    [SerializeField] float initalForce = 1f;
    [SerializeField] float initalTorque = 1f;
    [SerializeField] GameObject playerContactSound;
    AttractTo attractTo;
    Rigidbody rb;
    Collider collider;
    ParticleSystem bubbleBurst;

    float highlightTimer;
    Outline outline;
    bool interactable = true;
    private void Start() {
        outline = GetComponentInChildren<Outline>();
        bubbleBurst = GetComponentInChildren<ParticleSystem>();
    }

    private void TrashInteract() {
        // Initalize other values
        GetComponent<ScaleWobble>().ActivateWobble();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        attractTo = GetComponent<AttractTo>();
        Invoke("StartAttract", attractDelay);
        
        // Trash Updates
        interactable = false;
    }

    public void TrashClicked() {
        if (interactable) {
            TrashInteract();
            interactable = false;
            bubbleBurst.Play();

            // Random upward force
            Vector2 offset = Random.insideUnitCircle.normalized;
            Vector3 direction = new Vector3(offset.x, 1, offset.y).normalized;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(direction * initalForce, ForceMode.Impulse);
            rb.AddTorque(Random.onUnitSphere * initalTorque, ForceMode.Impulse);
        }
    }

    public void TrashCollision() {
        if (Interactable()) {
            TrashInteract();

            // Trash Updates
            StartAttract();
        }
    }

    public void StartAttract() {
        // Triggering attraction
        attractTo.Activate(FindObjectOfType<PlayerMovementController>().gameObject, ContactPlayer);

        // Disabling contact with terrain
        rb.useGravity = false;
        collider.isTrigger = true;
    }

    public void ContactPlayer() {
        FindObjectOfType<StatTracking>().IterateTrashCollected();
        FindObjectOfType<PlayerEffectController>().ScaleWobble(); // Wobble player model

        // Create Sound effect one shot
        Instantiate(playerContactSound, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void LateUpdate() {
        highlightTimer -= Time.deltaTime;
        if (highlightTimer < 0) {
            outline.enabled = false;
        }
    }

    public bool Interactable() {
        return interactable;
    }

    public void InteractHighlight() {
        highlightTimer = Time.deltaTime;
        outline.enabled = true;
    }

}
