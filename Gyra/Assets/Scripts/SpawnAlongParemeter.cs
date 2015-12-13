using UnityEngine;
using System.Collections;

// NOT a general spawner
public class SpawnAlongParemeter : MonoBehaviour 
{
	public float minSpawnInterval = 1.5f;
	public float maxSpawnInterval = 3.0f;
	public float smallestReducedInterval = 0.1f;
	public float reductionSpeed = 0.1f;
	public GameObject spawnedPrefab;
	public Vector3 anchorPoint = Vector3.zero;
	public float verticalRadius = 30.0f;
	public float horizontalRadius = 30.0f;
	public Transform target;

	private Vector3 rightHoriz;
	private Vector3 leftHoriz;
	private Vector3 topVertic;
	private Vector3 bottomVertic;
	public float progressIntervalOffset = 0.0f;
	private bool stopRoutines = false;



	// Use this for initialization
	void Start ()
	{
		Debug.Assert(this.spawnedPrefab != null, "Spawn Prefab needs to be defined in the spawner!");
		Debug.Assert(this.target != null, "Spanwer needs a target!");
		StartCoroutine(SpawnIndefinitely());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.progressIntervalOffset + this.minSpawnInterval > this.smallestReducedInterval)
		{
			this.progressIntervalOffset -= this.reductionSpeed * Time.deltaTime;
		}
	}

	void OnDestroy()
	{
		this.stopRoutines = true;
	}

	void OnDrawGizmos()
	{
		if(Application.isEditor)
		{
			Gizmos.color = Color.yellow;
			this.CalculateEdgeVectors();
			Gizmos.DrawWireCube(rightHoriz, new Vector3(1.0f, 1.0f, 2*this.verticalRadius));
			Gizmos.DrawWireCube(leftHoriz, new Vector3(1.0f, 1.0f, 2*this.verticalRadius));
			Gizmos.DrawWireCube(topVertic, new Vector3(2*this.horizontalRadius, 1.0f, 1.0f));
			Gizmos.DrawWireCube(bottomVertic, new Vector3(2*this.horizontalRadius, 1.0f, 1.0f));
		}
	}

	private void CalculateEdgeVectors()
	{
		this.rightHoriz = this.anchorPoint + new Vector3(this.horizontalRadius, 0.0f, 0.0f);
		this.leftHoriz = this.anchorPoint + new Vector3(-this.horizontalRadius, 0.0f, 0.0f);
		this.topVertic = this.anchorPoint + new Vector3(0.0f, 0.0f, this.verticalRadius);
		this.bottomVertic = this.anchorPoint + new Vector3(0.0f, 0.0f, -this.verticalRadius);
	}


	IEnumerator SpawnIndefinitely()
	{
		while(!this.stopRoutines)
		{
			// Wait random times
			float waitTime = Random.Range(this.minSpawnInterval, this.maxSpawnInterval);
			waitTime += this.progressIntervalOffset;
			yield return new WaitForSeconds(waitTime);

			// Spawn
			this.SpawnPrefab();
		}
	}


	private void SpawnPrefab()
	{
		GameObject newSpawned = GameObject.Instantiate<GameObject>(this.spawnedPrefab);
		Transform spawnedTransform = newSpawned.transform;

		float randomRotation = Random.Range(0.0f, 359.99f);
		Vector3 euler = spawnedTransform.rotation.eulerAngles;
		euler.Set(0.0f, randomRotation, 0.0f);
		spawnedTransform.eulerAngles = euler;

		Vector3 spawnPosition = Vector3.one * this.verticalRadius;
		float hOrV = Random.Range(0.0f, 1.0f);
		float posOrNeg = Random.Range(0.0f, 1.0f);
		if(hOrV < 0.5f)
		{
			if(posOrNeg < 0.5f)
			{
				// Position(+h, 0.0f, rand(-v,v))
				spawnPosition.Set(this.horizontalRadius, 0.0f, Random.Range(-this.verticalRadius, this.verticalRadius));
			}
			else
			{
				// Position(-h, 0.0f, rand(-v,v))
				spawnPosition.Set(-this.horizontalRadius, 0.0f, Random.Range(-this.verticalRadius, this.verticalRadius));
			}
		}
		else
		{
			if(posOrNeg < 0.5f)
			{
				// Position(rand(-h,h), 0.0f, +v)
				spawnPosition.Set(Random.Range(-this.horizontalRadius, this.horizontalRadius), 0.0f, this.verticalRadius);
			}
			else
			{
				// Position(rand(-h,h), 0.0f, -v)
				spawnPosition.Set(Random.Range(-this.horizontalRadius, this.horizontalRadius), 0.0f, -this.verticalRadius);
			}
		}

		spawnedTransform.position = spawnPosition;

		TurnTowardsTransform turnScript = newSpawned.GetComponent<TurnTowardsTransform>();
		Debug.Assert(turnScript != null, "TurnTowardsTransform Script not found in the Enemy prefab!");
		turnScript.target = this.target;
		turnScript.SetAccuracy(turnScript.Accuracy - this.progressIntervalOffset);
	}
}
