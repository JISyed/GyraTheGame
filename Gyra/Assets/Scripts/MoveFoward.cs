using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MoveFoward : MonoBehaviour 
{
	//public float speed = 10.0f;
	public float minSpeed = 7.0f;
	public float maxSpeed = 15.0f;
	public bool	accelerate = false;
	public float acceleration = 0.5f;
	public float speedToStopAccel = 50.0f;

	private Transform theTransform;
	private Rigidbody theRigidBody;
	private float currentSpeed;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.theRigidBody = this.GetComponent<Rigidbody>();
		this.currentSpeed = Random.Range(this.minSpeed, this.maxSpeed);
		// Quick start
		//this.theRigidBody.AddForce(this.theTransform.forward * (this.speed * 0.6f), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(this.accelerate)
		{
			this.currentSpeed += this.acceleration * Time.deltaTime;
			if(this.currentSpeed > this.speedToStopAccel)
			{
				this.currentSpeed = this.speedToStopAccel;
			}
		}

		this.theRigidBody.AddForce(this.theTransform.forward * (this.currentSpeed * Time.deltaTime), ForceMode.Impulse);
	}


}
