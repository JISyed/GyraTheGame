using UnityEngine;

public class VaryColorByScale : MonoBehaviour 
{
	[Range(0.0f, 1.0f)]public float minHue = 0.0f;
	[Range(0.0f, 1.0f)]public float maxHue = 0.9f;
	[Range(0.0f, 1.0f)]public float saturation = 0.9f;
	[Range(0.0f, 1.0f)]public float lightness = 0.5f;

	private float currentHue = 0.0f;
	private Material theMaterial;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.maxHue > this.minHue, "Min Hue cannot be greater than Max Hue");
		this.theMaterial = this.gameObject.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rawScale = ControlScale.CurrentScaleValue;
		this.currentHue = ControlScale.Rescale(rawScale, this.minHue, this.maxHue);

		this.theMaterial.color = ColorUtility.HSVToRGB(this.currentHue, this.saturation, this.lightness);
		this.theMaterial.SetColor("_EmissionColor", ColorUtility.HSVToRGB(this.currentHue, 0.7f, 0.4f));
	}
}
