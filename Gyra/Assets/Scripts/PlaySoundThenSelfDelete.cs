using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundThenSelfDelete : MonoBehaviour 
{
	public AudioClip soundToPlay;

	private AudioSource theAudioSource;

	// Use this for initialization
	void Start () 
	{
		this.theAudioSource = this.GetComponent<AudioSource>();
		this.theAudioSource.loop = false;
		this.theAudioSource.playOnAwake = false;
		this.theAudioSource.clip = this.soundToPlay;
		this.theAudioSource.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.theAudioSource.isPlaying == false)
		{
			Destroy(this.gameObject);
		}
	}
}
