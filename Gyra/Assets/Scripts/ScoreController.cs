using UnityEngine;

public class ScoreController : MonoBehaviour 
{
	public float minScoreIncrement = 1.0f;
	public float maxScoreIncrement = 20.0f;
	public float minKillBonusMultiplier = 1.0f;
	public float maxKillBonusMultiplier = 10.0f;


	public const string HighScoreKey = "highscore";

	private static ScoreController singetonInstance;


	private float currentScoreIncrement;
	private float currentKillBonusMultiplier;


	// Use this for initialization
	void Start () 
	{
		ScoreController.singetonInstance = this;
		this.currentScoreIncrement = this.minScoreIncrement;
		this.currentKillBonusMultiplier = this.minKillBonusMultiplier;

	}

	void OnDestroy()
	{
		ScoreController.singetonInstance = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rawScale = ControlScale.CurrentScaleValue;

		this.currentScoreIncrement = ControlScale.Rescale(rawScale, this.minScoreIncrement, this.maxScoreIncrement);
		this.currentKillBonusMultiplier = ControlScale.Rescale(rawScale, this.minKillBonusMultiplier, maxKillBonusMultiplier);


		// Add to the score, just for staying alive
		GameplayController.IncrementScore((int)this.currentScoreIncrement);
	}


	public static int GetKillBonusMultiplier()
	{
		Debug.Assert(ScoreController.singetonInstance != null, "ScoreController object needs to exist before calling GetKillBonusMultiplier()");
		return (int) ScoreController.singetonInstance.currentKillBonusMultiplier;
	}
}
