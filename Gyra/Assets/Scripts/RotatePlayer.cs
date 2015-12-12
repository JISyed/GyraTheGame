using UnityEngine;

public class RotatePlayer : MonoBehaviour 
{
	//public float rotateSpeed = 30.0f;
	public float minRotateSpeed = 20.0f;
	public float maxRotateSpeed = 40.0f;

	private Transform theTransform;	// Caching for performance

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rawScale = ControlScale.CurrentScaleValue;
		float rotationSpeed = ControlScale.Rescale(rawScale, this.minRotateSpeed, this.maxRotateSpeed);

		Vector3 newRot = this.theTransform.eulerAngles;
		newRot.Set(0.0f, newRot.y + rotationSpeed * Time.deltaTime, 0.0f);
		this.theTransform.eulerAngles = newRot;
	}
}
