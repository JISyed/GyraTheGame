using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyScript : MonoBehaviour 
{
	public int pointWorth = 20;
	[SerializeField] private GameObject coreCrashParticles;
	[SerializeField] private GameObject armCrashParticles;
	[SerializeField] private GameObject soundPlayForAttackingCore;
	[SerializeField] private GameObject soundPlayForDying;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.coreCrashParticles != null, "Need a particle object for the enemy-core collision!");
		Debug.Assert(this.armCrashParticles != null, "Need a particle object for the enemy-arm collision!");
		Debug.Assert(this.soundPlayForDying != null);
		Debug.Assert(this.soundPlayForAttackingCore != null);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag.Equals("Core"))
		{
			ControlScale.ShrinkForTime();
			GameplayController.DecrementLives();
			GameObject.Instantiate(this.coreCrashParticles, this.transform.position, this.transform.rotation);
			GameObject.Instantiate(this.soundPlayForAttackingCore);
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag.Equals("Arm"))
		{
			GameplayController.IncrementScore(this.pointWorth);
			GameObject.Instantiate(this.armCrashParticles, this.transform.position, other.gameObject.transform.rotation);
			GameObject.Instantiate(this.soundPlayForDying);
			Destroy(this.gameObject);
		}
	}
}
