using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyScript : MonoBehaviour 
{


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag.Equals("Core"))
		{
			//Debug.Log("Miku!");
			ControlScale.ShrinkForTime();
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag.Equals("Arm"))
		{
			//Debug.Log("Crash!");
		}
	}
}
