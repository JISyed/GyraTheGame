using UnityEngine;

public class DeleteSelfAfterTime : MonoBehaviour 
{
	public float lifeTime = 3.0f;

	// Use this for initialization
	void Start () 
	{
		Destroy(this.gameObject, this.lifeTime);
	}
}
