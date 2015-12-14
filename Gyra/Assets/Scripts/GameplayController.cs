using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class GameplayController : MonoBehaviour 
{
	public UI.Text scoreText;
	public UI.Text livesText;
	public GameObject gameOverPanel;
	public GameObject highscoreTextObj;
	public int startingLives = 10;
	
	private int score;
	private int lives;
	private int highscore;
	private bool isGameOver = false;

	private static GameplayController singetonInstance;

	// Use this for initialization
	void Start () 
	{
		GameplayController.singetonInstance = this;
		Debug.Assert(this.scoreText != null, "GamePlayController needs the UI.Text to display the Score!");
		Debug.Assert(this.livesText != null, "GamePlayController needs the UI.Text to display the Lives!");
		Debug.Assert(this.gameOverPanel != null, "GamePlayController needs the panel object for Game Over!");
		Debug.Assert(this.highscoreTextObj != null, "GamePlayController needs the UI.Text's object for declaring highscore!");

		this.gameOverPanel.SetActive(false);
		this.highscoreTextObj.SetActive(false);

		if(PlayerPrefs.HasKey(ScoreController.HighScoreKey))
		{
			this.highscore = PlayerPrefs.GetInt(ScoreController.HighScoreKey);
		}
		else
		{
			this.highscore = 0;
		}

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
		if(lives < 1)
		{
			this.ShowGameOver();
		}

		if(Input.GetKeyUp(KeyCode.Escape))
		{
			this.LeaveToMenu();
		}
	}


	private void SetScore(int newScore)
	{
		if(!this.isGameOver)
		{
			this.score = newScore;
			this.scoreText.text = this.score.ToString();
		}
	}

	private void SetLives(int newLives)
	{
		if(!this.isGameOver)
		{
			this.lives = newLives;
			this.livesText.text = this.lives.ToString();
		}
	}

	private void AddScore(int newAddAmount)
	{
		this.SetScore(this.score + newAddAmount);
	}

	private void AddLives(int newAddAmount)
	{
		this.SetLives(this.lives + newAddAmount);
	}

	private void SaveHighscore()
	{
		if(this.score > this.highscore)
		{
			this.highscore = this.score;
			PlayerPrefs.SetInt(ScoreController.HighScoreKey, this.highscore);
			PlayerPrefs.Save();
		}
	}

	private void ShowGameOver()
	{
		if(!this.isGameOver)
		{
			this.isGameOver = true;
			ControlScale.DisableTheControls();
			this.gameOverPanel.SetActive(true);
			if(this.score > this.highscore)
			{
				this.highscoreTextObj.SetActive(true);
				this.SaveHighscore();
			}
			else 
			{
				this.highscoreTextObj.SetActive(false);
			}
		}
	}



	public void LeaveToMenu()
	{
		this.SaveHighscore();
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
