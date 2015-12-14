using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class GameplayController : MonoBehaviour 
{
	public UI.Text scoreText;
	public UI.Text livesText;

	private static GameplayController singetonInstance;

	// Use this for initialization
	void Start () 
	{
		GameplayController.singetonInstance = this;
	}

	void OnDestroy()
	{
		GameplayController.singetonInstance = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void LeaveToMenu()
	{
		Application.LoadLevel(0);	// Index 0 should be the Menu scene
	}
}
