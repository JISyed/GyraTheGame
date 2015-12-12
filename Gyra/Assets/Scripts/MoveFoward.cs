using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MoveFoward : MonoBehaviour 
{
	public float speed = 10.0f;

	private Transform theTransform;
	private Rigidbody theRigidBody;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.theRigidBody = this.GetComponent<Rigidbody>();

		// Quick start
		this.theRigidBody.AddForce(this.theTransform.forward * this.speed, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//this.theRigidBody.AddForce(this.theTransform.forward * (this.speed* Time.deltaTime), ForceMode.Force);
	}
}
