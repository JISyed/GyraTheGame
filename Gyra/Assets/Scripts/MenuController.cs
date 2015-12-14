using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class MenuController : MonoBehaviour 
{
	public UI.Text highscoreDisplay;
	public GameObject helpPanel;
	public GameObject creditsPanel;

	private int highscore = 0;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.highscoreDisplay != null, "Menu Controller needs a UI.Text to display the highscore!");
		Debug.Assert(this.helpPanel != null, "Menu Controller needs the gameobject for the Help Panel!");
		Debug.Assert(this.creditsPanel != null, "Menu Controller needs the gameobject for the Credits Panel!");
		this.helpPanel.SetActive(false);
		this.creditsPanel.SetActive(false);
		this.LoadHighscore();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if(this.helpPanel.activeSelf)
			{
				this.DeactivateHelpPanel();
			}
			else if(this.creditsPanel.activeSelf)
			{
				this.DeactivateCreditsPanel();
			}
			else
			{
				Application.Quit();
				if(Application.isEditor)
				{
					Debug.Log("Application would quit in final builds.");
				}
			}
		}

		if(Input.GetKeyUp(KeyCode.Return))
		{
			this.GoToGamePlay();
		}
	}


	private void LoadHighscore()
	{
		if(PlayerPrefs.HasKey(ScoreController.HighScoreKey))
		{
			this.highscore = PlayerPrefs.GetInt(ScoreController.HighScoreKey);
		}
		else
		{
			this.highscore = 0;
		}
		this.highscoreDisplay.text = this.highscore.ToString();
	}


	public void ActivateHelpPanel()
	{
		this.helpPanel.SetActive(true);
	}

	public void DeactivateHelpPanel()
	{
		this.helpPanel.SetActive(false);
	}

	public void ActivateCreditsPanel()
	{
		this.creditsPanel.SetActive(true);
	}
	
	public void DeactivateCreditsPanel()
	{
		this.creditsPanel.SetActive(false);
	}

	public void GoToGamePlay()
	{
		Application.LoadLevel(1);	// 1 should be the Gameplay scene
	}

}
