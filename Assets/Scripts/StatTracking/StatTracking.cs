using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DiveStats {
    public int coralFragmentsPickedup;
    public int coralHammered;
    public float trashCollected;
    public float coralPlaced;
    public int eelCollisions;
    public int pufferCollisions;
}

public class StatTracking : MonoBehaviour
{
    public List<DiveStats> stats = new List<DiveStats>();
    public DiveStats currentStats;
    public int trashTotal = 0;
    public int trashCollected = 0;
    public int totalCoralPlaceable = 0;

    private void Start() {
        trashTotal = FindObjectsOfType<Trash>().Length;

        // Initalizing size to 3
        for(int i = 0; i < 3; i++) {
            stats.Add(new DiveStats());
        }

        // Getting total number of placeable coral
        int totalPlaceable = 0;
        CoralPlaceableArea[] coralPlaceableAreas = FindObjectsOfType<CoralPlaceableArea>();
        foreach (CoralPlaceableArea area in coralPlaceableAreas) {
            if (area.areaType == AreaType.REEF) {
                totalPlaceable += area.maxCoralPlacable;
            }
        }
        totalCoralPlaceable = totalPlaceable;

        ResetCurrentStats();
    }
    public void SaveStats(int diveNumber) {
        currentStats.coralPlaced = CalculateCoralPlaced();
        currentStats.trashCollected = trashCollected;

        Debug.Log(diveNumber);
        if(diveNumber < 3 && diveNumber >= 0) {
            stats[diveNumber] = currentStats;
        }
        ResetCurrentStats();
    }

    public float CalculateCoralPlaced() {
        int totalPlacedCoral = 0;
        // Finding hammered in juvenile coral
        JuvenileCoral[] juvenileCorals = FindObjectsOfType<JuvenileCoral>();
        foreach (JuvenileCoral juvenileCoral in juvenileCorals) {
            if (juvenileCoral.IsHammeredIn()) {
                totalPlacedCoral++;
            }
        }
        // Finding adult coral
        AdultCoral[] adultCorals = FindObjectsOfType<AdultCoral>();
        totalPlacedCoral += adultCorals.Length;

        // Limiting percent
        return totalPlacedCoral;
    }

    public void ResetCurrentStats() {
        currentStats.coralFragmentsPickedup = 0;
        currentStats.coralHammered = 0;
        currentStats.trashCollected = 0;
        currentStats.coralPlaced = 0;
        currentStats.eelCollisions = 0;
        currentStats.pufferCollisions = 0;
    }
    public void IteratePufferCollision() {
        currentStats.pufferCollisions++;
    }
    public void IterateEelCollision() {
        currentStats.eelCollisions++;
    }
    public void IterateTrashCollected() {
        trashCollected++;
    }
    public void IterateCoralPickup() {
        currentStats.coralFragmentsPickedup++;
    }
    public void IterateCoralHammered() {
        currentStats.coralHammered++;
    }
}
