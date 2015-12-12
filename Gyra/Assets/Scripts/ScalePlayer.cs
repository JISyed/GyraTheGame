using UnityEngine;
using System.Collections;

public class ScalePlayer : MonoBehaviour 
{
	public float scaleSpeed = 9.0f;

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

		if(TwoButtonDelegator.GetGrowButton())
		{
			newScale += Vector3.one * (this.scaleSpeed * Time.deltaTime);
		}
		else if(TwoButtonDelegator.GetShrinkButton())
		{
			newScale += Vector3.one * (-this.scaleSpeed * Time.deltaTime);
		}

		this.theTransform.localScale = newScale;
	}
}
