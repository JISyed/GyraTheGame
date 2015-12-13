using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MoveFoward : MonoBehaviour 
{
	public float speed = 10.0f;
	public bool	accelerate = false;
	public float acceleration = 0.5f;
	public float maxSpeed = 50.0f;

	private Transform theTransform;
	private Rigidbody theRigidBody;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.theRigidBody = this.GetComponent<Rigidbody>();

		// Quick start
		//this.theRigidBody.AddForce(this.theTransform.forward * (this.speed * 0.6f), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(this.accelerate)
		{
			this.speed += this.acceleration * Time.deltaTime;
			if(this.speed > this.maxSpeed)
			{
				this.speed = this.maxSpeed;
			}
		}

		this.theRigidBody.AddForce(this.theTransform.forward * (this.speed * Time.deltaTime), ForceMode.Impulse);
	}


}
