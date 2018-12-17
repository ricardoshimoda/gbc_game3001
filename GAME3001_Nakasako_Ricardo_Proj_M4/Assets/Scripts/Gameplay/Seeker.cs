using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float seekSpeed;
	[SerializeField] private float rotSpeed;
	[SerializeField] private float slowDist; 
	[SerializeField] private float stopDist; 
	[SerializeField] private float seekDist; 
	[SerializeField] GameObject rock; // Prefab to create the projectile
	[SerializeField] Transform rockSpawn; // Where the projectile is instantiated

	private Transform targetObj;
	private bool isMoving; // This flag controls whether or not the actor is moving. Set false when arrived.
	private bool isWandering;
	private Vector3 initialPosWandering;
	private bool getNewInitialWandering;
	private float distWander;

	private Vector3 destVect; // Direction to target. Calculated each frame in Update.
	private Quaternion destRot; // Desired rotation to target. Calculated each frame in Update.
	private float distTo; // Distance to target. Calculated each frame in Update.
	private bool firstLog = true;
	private bool firstStone = true;

	private GameObject[] spawnPoints;

	void Start()
	{
		targetObj =  GameObject.FindGameObjectWithTag("Hero").transform;
		spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		GetNewDest ();
		SetWandering(true);
	}

	void Update () {
		if(targetObj == null || spawnPoints == null) return;
		distTo = Vector3.Distance(transform.position, targetObj.position);
		if (isMoving) {
			firstStone = true;
			if (isWandering) {
				if (getNewInitialWandering) {
					initialPosWandering = transform.position;
					getNewInitialWandering = false;
					distWander = 0.0f;
				}
				distWander = Vector3.Distance (transform.position, initialPosWandering);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, destRot, rotSpeed * Time.deltaTime);
				if (distWander > 10) {
					GetNewDest ();
					getNewInitialWandering = true;
					Debug.Log ("Changing Wandering direction1");
				}
				if (transform.rotation == destRot) {
					GetNewDest ();
					Debug.Log ("Changing Wandering direction2");

				}
				transform.Translate (Vector3.forward * (moveSpeed * Mathf.Clamp ((distTo / slowDist), 0.0F, 1.0F) * Time.deltaTime));
			} else { // chasing 
				destVect = targetObj.position - transform.position;
				destRot = Quaternion.LookRotation (destVect);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, destRot, rotSpeed * Time.deltaTime);
				transform.eulerAngles = new Vector3 (0.0F, transform.eulerAngles.y, 0.0F); // Zeroing out all but Y rotation. 2.5D
				//Move along Z...
				transform.Translate (Vector3.forward * (seekSpeed * Mathf.Clamp ((distTo / slowDist), 0.0F, 1.0F) * Time.deltaTime));
			}

		} else {
			if (firstStone) {
				firstStone = false;
				Invoke ("ShootRock", Random.Range (5, 10));
			}
		}
		if (distTo <= stopDist) {
			SetMoving (false);
		} else if (distTo <= slowDist) {
			SetMoving (true);
		} else if (distTo <= seekDist) {
			Debug.Log ("Seeking");
			SetWandering (false);
			SetMoving (true);
		} else {
			Debug.Log ("Wandering");
			SetWandering (true);
		}
	}

	void ShootRock(){
		return;
		Instantiate (rock, rockSpawn.position, rockSpawn.rotation);
		Invoke ("ShootRock", Random.Range (5, 10));
	}

	public void SetMoving(bool toggle)
	{
		isMoving = toggle; //for motion
	}

	public void SetWandering(bool toggle){
		getNewInitialWandering = toggle;
		isWandering = toggle;
		SetMoving (toggle);
	}

	private void GetNewDest(){
		getNewInitialWandering = true;
		int indexNewDestination = Random.Range(0,spawnPoints.Length-1);
		destRot = spawnPoints[indexNewDestination].transform.rotation;
	}
}
