using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingScooter : Upgrade {
    /// <summary>
    /// Each of these values are added onto the base values established in the player prefab
    /// </summary>

    [SerializeField] float horizontalAcceleration;
    [SerializeField] float horizontalMaxSpeed;
    [SerializeField] float verticalAccelleration;
    [SerializeField] float verticalMaxSpeed;
    [SerializeField] float gravityAccel;
    [SerializeField] float maxFallSpeed;
    [SerializeField] float friction;

    public override void UpgradeTrigger() {
        Debug.Log("Scooter upgrade");

        PlayerMovementController playerMovement = FindObjectOfType<PlayerMovementController>();
        playerMovement.horizontalAcceleration += horizontalAcceleration;
        playerMovement.horizontalMaxSpeed += horizontalMaxSpeed;
        playerMovement.verticalAccelleration += verticalAccelleration;
        playerMovement.verticalMaxSpeed += verticalMaxSpeed;
        playerMovement.gravityAccel += gravityAccel;
        playerMovement.maxFallSpeed += maxFallSpeed;
        playerMovement.friction += friction;
    }
}
