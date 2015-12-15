using UnityEngine;

public class TriggerCoreDeathOnGameOver : MonoBehaviour 
{
	[SerializeField] private GameObject deathParticleObj;
	[SerializeField] private GameObject[] arms;

	private Renderer coreRenderer;
	private Collider coreCollider;
	private AudioSource theAudioSource;
	private bool isGameOver;

	// Use this for initialization
	void Start () 
	{
		Debug.Assert(this.deathParticleObj != null, "Prefab for Core Death Particles needed!");
		this.coreRenderer = this.gameObject.GetComponent<Renderer>();
		this.isGameOver = false;

		this.coreCollider = this.gameObject.GetComponent<Collider>();
		this.theAudioSource = this.gameObject.GetComponent<AudioSource>();

		Debug.Assert(this.arms.Length > 0, "Core Game Over script needs reference to arms!");
		foreach(GameObject armObj in this.arms)
		{
			Debug.Assert(armObj != null, "An arm gameobject in the Arms array is missing!");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameplayController.GetLives() <= 0)
		{
			if(!this.isGameOver)
			{
				this.isGameOver = true;
				this.coreRenderer.enabled = false;
				this.coreCollider.enabled = false;
				this.theAudioSource.Play();
				GameObject.Instantiate(this.deathParticleObj, this.transform.position, this.transform.rotation);

				foreach(GameObject armObj in this.arms)
				{
					Collider armCollider = armObj.GetComponent<Collider>();
					armCollider.enabled = false;
				}
			}
		}
	}
}
