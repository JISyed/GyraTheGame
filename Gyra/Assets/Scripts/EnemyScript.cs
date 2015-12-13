using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyScript : MonoBehaviour 
{
	public int pointWorth = 20;
	[SerializeField] private GameObject coreCrashParticles;
	[SerializeField] private GameObject armCrashParticles;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.coreCrashParticles != null, "Need a particle object for the enemy-core collision!");
		Debug.Assert(this.armCrashParticles != null, "Need a particle object for the enemy-arm collision!");
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag.Equals("Core"))
		{
			ControlScale.ShrinkForTime();
			GameObject.Instantiate(this.coreCrashParticles, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag.Equals("Arm"))
		{
			GameObject.Instantiate(this.armCrashParticles, this.transform.position, other.gameObject.transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
