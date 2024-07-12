using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Events; 

public class HydroVents : MonoBehaviour
{
	Rigidbody rb; 
	[SerializeField] Transform currentDirection;
	[SerializeField] float currentForce;
	[SerializeField] float maxSpeed;

	[SerializeField] string playerTag;
	[SerializeField] public UnityEvent OnOxygenDuration = new UnityEvent(); 
	[SerializeField] public float oxygenDuration; 
	[HideInInspector] public float timer = 0; 
	PlayerMovementController movementController; 

	private void Start()
	{
		movementController = FindObjectOfType<PlayerMovementController>();
		rb = GetComponent<Rigidbody>();
	}

	private void OnTriggerStay(Collider collision)
	{
		if (collision.tag == playerTag && movementController != null){
			movementController.AddVelocity(currentForce * currentDirection.up, maxSpeed); 
		}
	 FindAnyObjectByType<Oxygen>();
	}
}
