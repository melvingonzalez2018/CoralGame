using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroVentCollider : MonoBehaviour
{
    [SerializeField] GameObject tempVisual;
    [SerializeField] CapsuleCollider col;
    PlayerMovementController movementController;
    PlayerStun playerStun;
    float currentForce;
    float maxSpeed;
    float oxygenDurationLoss;


    // Start is called before the first frame update
    void Start() {
        movementController = FindObjectOfType<PlayerMovementController>();
        playerStun = FindObjectOfType<PlayerStun>();
    }

    public void InitalizeVent(float currentForce, float maxSpeed, float oxygenDurationLoss, float ventDuration, float height, float width) {
        this.currentForce = currentForce;
        this.maxSpeed = maxSpeed;
        this.oxygenDurationLoss = oxygenDurationLoss;
        Invoke("DestroySelf", ventDuration);

        col.height = height;
        col.radius = width/2;

        tempVisual.transform.localScale = new Vector3(width, height/2, width);
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }


    void OnTriggerStay(Collider collision) {
        if (collision.gameObject.tag == "Player" && movementController != null) {
            movementController.AddVelocity(currentForce * transform.up, maxSpeed);
            playerStun.ReduceOxygen(oxygenDurationLoss);
        }
    }
}
