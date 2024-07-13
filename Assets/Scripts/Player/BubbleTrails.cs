using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class BubbleTrails : MonoBehaviour
{

	
	[SerializeField] float emitAmountH;
	[SerializeField] float emitAmountV; 
	void Start()
	{

     ParticleSystem ps = GetComponent<ParticleSystem>();
	PlayerController playerController = ps.GetComponent<PlayerController>();
		var em = ps.emission;
		em.enabled = true; 
	}
	void Update()
	{
        float checkH = Input.GetAxisRaw("Horizontal");
		float checkV = Input.GetAxisRaw("Vertical");

        if (checkH == checkV)
		{
			emitAmountH = checkH * 2f;  
			emitAmountV = checkV * 2f;   
		} 

	}

		
}

