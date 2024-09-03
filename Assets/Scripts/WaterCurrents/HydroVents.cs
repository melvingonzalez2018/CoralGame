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

	
=======
	
	[HideInInspector] public float timer = 0;

	Oxygen oxygen; 
	Vector3 bounceHeight; 

	PlayerMovementController movementController; 

	private void Start()
	{
		movementController = FindObjectOfType<PlayerMovementController>();
		rb = GetComponent<Rigidbody>();
        oxygen = FindObjectOfType<Oxygen>();
    }

	private void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.tag == "Player" && movementController != null)
		{
<<<<<<< Updated upstream
			movementController.AddVelocity(currentForce * currentDirection.forward, maxSpeed); 
=======
			movementController.AddVelocity(currentForce * currentDirection.forward, maxSpeed);
				oxygen.ReduceOxygen(oxygenDuration); 
>>>>>>> Stashed changes
		}
	 FindAnyObjectByType<Oxygen>();
	}
}
