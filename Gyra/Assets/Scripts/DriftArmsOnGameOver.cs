using UnityEngine;

public class DriftArmsOnGameOver : MonoBehaviour 
{
	public float minDriftSpeed = 5.0f;
	public float maxDriftSpeed = 10.0f;

	private Transform theTransform;
	private float driftSpeed;
	private Vector3 randomDriftRotation;


	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.driftSpeed = Random.Range(this.minDriftSpeed, this.maxDriftSpeed);
		this.randomDriftRotation = Random.onUnitSphere;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameplayController.IsGameOver())
		{
			Vector3 newPosition = this.theTransform.position;
			newPosition = newPosition + this.transform.right * (this.driftSpeed * Time.deltaTime);
			this.theTransform.position = newPosition;

			Vector3 newRotation = this.theTransform.rotation.eulerAngles;
			newRotation = newRotation + this.randomDriftRotation * (this.driftSpeed * 2.0f * Time.deltaTime);
			this.theTransform.eulerAngles = newRotation;
		}
	}
}
