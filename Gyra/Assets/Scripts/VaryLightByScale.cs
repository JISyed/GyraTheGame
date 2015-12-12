using UnityEngine;
using System.Collections;

public class VaryLightByScale : MonoBehaviour 
{
	[Range(0.0f, 8.0f)]public float minIntensity = 1.0f;
	[Range(0.0f, 8.0f)]public float maxIntensity = 5.0f;
	[Range(0.0f, 1.0f)]public float minHue = 0.0f;
	[Range(0.0f, 1.0f)]public float maxHue = 0.9f;
	[Range(0.0f, 1.0f)]public float saturation = 0.9f;
	[Range(0.0f, 1.0f)]public float lightness = 0.5f;
	
	private float currentHue = 0.0f;
	private float currentIntensity = 1.0f;
	private Light theLight;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.maxHue > this.minHue, "Min Hue cannot be greater than Max Hue");
		Debug.Assert(this.maxIntensity > this.minIntensity, "Min Intensity cannot be greater than Max Intensity");
		this.theLight = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rawScale = ControlScale.CurrentScaleValue;

		this.currentHue = ControlScale.Rescale(rawScale, this.minHue, this.maxHue);
		this.theLight.color = ColorUtility.HSVToRGB(this.currentHue, this.saturation, this.lightness);

		this.currentIntensity = ControlScale.Rescale(rawScale, this.minIntensity, this.maxIntensity);
		this.theLight.intensity = this.currentIntensity;
	}
}
