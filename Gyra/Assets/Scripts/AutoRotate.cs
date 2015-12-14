using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour 
{
	public float rotationSpeed = -10.0f;

	private Transform theTransform;
	private float currentYRotation = 0.0f;
	private Vector3 newEulerAngle;
 
	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.currentYRotation += this.rotationSpeed * Time.deltaTime;
		this.newEulerAngle.Set(0.0f, this.currentYRotation, 0.0f);
		this.theTransform.eulerAngles = this.newEulerAngle;
	}
}
