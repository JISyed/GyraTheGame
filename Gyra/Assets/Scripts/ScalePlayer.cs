using UnityEngine;
using System.Collections;

public class ScalePlayer : MonoBehaviour 
{
	public float minScale = 2.0f;
	public float maxScale = 25.0f;

	private Transform theTransform; // Caching for performance

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newScale = theTransform.localScale;

		float rawScale = ControlScale.CurrentScaleValue;
		float finalScale = ControlScale.Rescale(rawScale, this.minScale, this.maxScale);

		newScale.Set(finalScale, finalScale, finalScale);
		this.theTransform.localScale = newScale;
	}
}
