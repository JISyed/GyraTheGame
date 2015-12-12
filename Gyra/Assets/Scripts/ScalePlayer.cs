using UnityEngine;
using System.Collections;

public class ScalePlayer : MonoBehaviour 
{
	public float scaleSpeed = 9.0f;
	public float minScale = 2.0f;
	public float maxScale = 25.0f;

	private Transform theTransform; // Caching for performance
	private float currentScale;	// Uniform scaling

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.currentScale = this.theTransform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newScale = theTransform.localScale;

		if(TwoButtonDelegator.GetGrowButton())
		{
			this.currentScale += (this.scaleSpeed * Time.deltaTime);
			if(this.currentScale > this.maxScale)
			{
				this.currentScale = this.maxScale;
			}
			newScale.Set(this.currentScale, this.currentScale, this.currentScale);
		}
		else if(TwoButtonDelegator.GetShrinkButton())
		{
			this.currentScale += (-this.scaleSpeed * Time.deltaTime);
			if(this.currentScale < this.minScale)
			{
				this.currentScale = this.minScale;
			}
			newScale.Set(this.currentScale, this.currentScale, this.currentScale);
		}

		this.theTransform.localScale = newScale;
	}
}
