using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Events; 

public class HydroVents : MonoBehaviour
{
    [Header("Hydro Vent Collider")]
    [SerializeField] GameObject hydroVentCollider;
	[SerializeField] float acceleration;
	[SerializeField] float maxSpeed;
    [SerializeField] float oxygenDurationLoss;
    [SerializeField] float ventHeight;
    [SerializeField] float ventWidth;

    [Header("Hydro Vent")]
    [SerializeField] float ventDuration;
    [SerializeField] float timeBetweenVents;

    private void Start() {
        Invoke("SpawnVent", timeBetweenVents);
    }

    private void SpawnVent() {
        GameObject vent = Instantiate(hydroVentCollider, transform);
        vent.GetComponent<HydroVentCollider>().InitalizeVent(acceleration, maxSpeed, oxygenDurationLoss, ventDuration, ventHeight, ventWidth);
        vent.transform.position += transform.up * (ventHeight / 2);
        Invoke("SpawnVent", timeBetweenVents);
    }
}
