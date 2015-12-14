using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class GameplayController : MonoBehaviour 
{
	public UI.Text scoreText;
	public UI.Text livesText;
	public int startingLives = 10;
	
	private int score;
	private int lives;

	private static GameplayController singetonInstance;

	// Use this for initialization
	void Start () 
	{
		GameplayController.singetonInstance = this;
		Debug.Assert(this.scoreText != null, "GamePlayController needs the UI.Text to display the Score!");
		Debug.Assert(this.livesText != null, "GamePlayController needs the UI.Text to display the Lives!");

		this.SetScore(0);
		this.SetLives(this.startingLives);
	}

	void OnDestroy()
	{
		GameplayController.singetonInstance = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	private void SetScore(int newScore)
	{
		this.score = newScore;
		this.scoreText.text = this.score.ToString();
	}

	private void SetLives(int newLives)
	{
		this.lives = newLives;
		this.livesText.text = this.lives.ToString();
	}

	private void AddScore(int newAddAmount)
	{
		this.SetScore(this.score + newAddAmount);
	}

	private void AddLives(int newAddAmount)
	{
		this.SetLives(this.lives + newAddAmount);
	}


	public void LeaveToMenu()
	{
		Application.LoadLevel(0);	// Index 0 should be the Menu scene
	}


	public static void IncrementScore(int incrementationAmount)
	{
		Debug.Assert(GameplayController.singetonInstance != null, "GamePlayController needs to exist to use IncrementScore()!");
		GameplayController.singetonInstance.AddScore(incrementationAmount);
	}

	public static void DecrementLives()
	{
		Debug.Assert(GameplayController.singetonInstance != null, "GamePlayController needs to exist to use DecrementLives()!");
		GameplayController.singetonInstance.AddLives(-1);
	}

	public static void IncremetnLives()
	{
		Debug.Assert(GameplayController.singetonInstance != null, "GamePlayController needs to exist to use IncremetnLives()!");
		GameplayController.singetonInstance.AddLives(1);
	}

	public static int GetScore()
	{
		Debug.Assert(GameplayController.singetonInstance != null, "GamePlayController needs to exist to use GetScore()!");
		return GameplayController.singetonInstance.score;
	}

	public static int GetLives()
	{
		Debug.Assert(GameplayController.singetonInstance != null, "GamePlayController needs to exist to use GetLives()!");
		return GameplayController.singetonInstance.lives;
	}


}
