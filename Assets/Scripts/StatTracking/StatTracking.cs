using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracking : MonoBehaviour
{
    [SerializeField] public int adultCoralGoal;
    [Header("Stats")]
    public int coralPickup;
    public int coralHammered;
    public int coralGrown;
    public int trashCollected;
    public int trashTotal;
    public int eelCollisions;
    public int pufferCollisions;
    private void Start() {
        trashTotal = FindObjectsOfType<Trash>().Length;
    }

    public void IteratePufferCollision() {
        pufferCollisions++;
    }
    public void IterateEelCollision() {
        eelCollisions++;
    }
    public void IterateTrashCollected() {
        trashCollected++;
    }
    public void IterateCoralPickup() {
        coralPickup++;
    }
    public void IterateCoralHammered() {
        coralHammered++;
    }
    public void IterateCoralGrown() {
        coralGrown++;
    }
}
