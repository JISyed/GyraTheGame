using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayMusicInAnyScene : MonoBehaviour 
{
	private AudioSource theAudioSource;

	// Null in beginning of program
	private static PlayMusicInAnyScene onlyInstance = null;

	// Use this for initialization
	void Start () 
	{
		// Delete any new instnaces of the music player
		if(PlayMusicInAnyScene.onlyInstance != null)
		{
			Destroy(this.gameObject);
			return;
		}

		PlayMusicInAnyScene.onlyInstance = this;

		this.theAudioSource = this.gameObject.GetComponent<AudioSource>();
		this.theAudioSource.playOnAwake = false;
		this.theAudioSource.loop = true;
		this.theAudioSource.Play();

		// This object will exist until the game closes
		DontDestroyOnLoad(this.gameObject);
	}
}
