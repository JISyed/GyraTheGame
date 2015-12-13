using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurnTowardsTransform : MonoBehaviour 
{
	public Transform target;
	[Range(0.0f, 1.0f)][SerializeField] private float accuracy = 0.9f;
	[Range(0.0f, 90.0f)] public float leastAccurateAngle = 30.0f;
	[Range(0.5f, 1.0f)] public float maxAllowedAccuracy = 0.875f;

	private Transform theTransform;
	private Rigidbody theRigidBody;
	private float invertAccuracy = 0.1f;	// Actual value used for accuracy logic
	private float angleAccuracy = 0.0f;
	//private float oldAngularDrag;
	//private float stopperAngularDrag = 10000.0f;


	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.theRigidBody = this.GetComponent<Rigidbody>();

		this.theRigidBody.AddTorque(Vector3.up * 0.5f, ForceMode.Impulse);
		//this.oldAngularDrag = this.theRigidBody.angularDrag;

		// Too much accuracy causes "angle tunneling"
		if(this.accuracy > this.maxAllowedAccuracy)
		{
			this.accuracy = this.maxAllowedAccuracy;
		}

		Debug.Assert(this.target != null, "Target transform needs to be applied for TurnTowardsTransform");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		this.invertAccuracy = this.InvertNormalization(this.accuracy);
		this.angleAccuracy = this.invertAccuracy * this.leastAccurateAngle;

		Vector3 headingtoTarget = this.target.position - this.theTransform.position;
		headingtoTarget.Normalize();
		float angleDifference = Vector3.Angle(this.theTransform.forward, headingtoTarget);
		if(angleDifference > this.angleAccuracy) 
		{
			float facingFactor = Vector3.Dot(this.theTransform.forward, headingtoTarget);
			if(facingFactor < 0.0f)
			{
				facingFactor = 0.0f;
			}
			facingFactor = this.InvertNormalization(facingFactor);
			this.theRigidBody.AddTorque(Vector3.up * facingFactor, ForceMode.Force);
			//this.theRigidBody.angularDrag = this.oldAngularDrag;
		}
		else
		{
			this.theRigidBody.AddTorque(-this.theRigidBody.angularVelocity, ForceMode.Impulse);
			this.theRigidBody.AddTorque(-this.theRigidBody.angularVelocity, ForceMode.Force);
			//this.theRigidBody.angularVelocity = Vector3.zero;
		}
	}

	/// <summary>
	/// 	Old value must be between 0 and 1
	/// </summary>
	private float InvertNormalization(float old)
	{
		return Mathf.Abs(old - 1.0f);
	}



	//
	// Propeties
	//

	public float Accuracy
	{
		get
		{
			return this.accuracy;
		}
	}

	public void SetAccuracy(float newAccuracy)
	{
		// Clamp
		newAccuracy = Mathf.Clamp(newAccuracy, 0.0f, 1.0f);

		// Set
		this.accuracy = newAccuracy;
		if(this.accuracy > this.maxAllowedAccuracy)
		{
			this.accuracy = this.maxAllowedAccuracy;
		}
	}
}
