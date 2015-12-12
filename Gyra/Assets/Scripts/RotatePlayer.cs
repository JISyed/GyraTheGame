using UnityEngine;

public class RotatePlayer : MonoBehaviour 
{
	public float rotateSpeed = 30.0f;

	private Transform theTransform;	// Caching for performance

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newRot = this.theTransform.eulerAngles;
		newRot.Set(0.0f, newRot.y + this.rotateSpeed * Time.deltaTime, 0.0f);
		this.theTransform.eulerAngles = newRot;
	}
}
