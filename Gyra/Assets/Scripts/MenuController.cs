using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class MenuController : MonoBehaviour 
{
	public UI.Text highscoreDisplay;
	public GameObject helpPanel;
	//public GameObject creditsPanel;

	private int highscore = 0;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.highscoreDisplay != null, "Menu Controller needs a UI.Text to display the highscore!");
		Debug.Assert(this.helpPanel != null, "Menu Controller needs the gameobject for the Help Panel!");
		this.helpPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
	}


	public void ActivateHelpPanel()
	{
		this.helpPanel.SetActive(true);
	}

	public void DeactivateHelpPanel()
	{
		this.helpPanel.SetActive(false);
	}

}
