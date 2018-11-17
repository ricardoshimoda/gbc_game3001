using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	[SerializeField] GameObject[] projectilePrefab; // Prefab to create the projectile
	[SerializeField] Transform projectileSpawn; // Where the projectile is instantiated
	int currentAmmo = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		ChangeAmmo ();
		FireInput ();
	}

	void ChangeAmmo(){
		if (Input.GetKeyDown (KeyCode.F1)) {
			currentAmmo = 0;
		} else if (Input.GetKeyDown (KeyCode.F2)) {
			currentAmmo = 1;
		} else if (Input.GetKeyDown (KeyCode.F3)) {
			currentAmmo = 2;
		} else if (Input.GetKeyDown (KeyCode.F4)) {
			currentAmmo = 3;
		} else if (Input.GetKeyDown (KeyCode.F5)) {
			currentAmmo = 4;
		} 
	}


	void FireInput ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log (projectilePrefab, projectileSpawn);
			//Quaternion rot = new Quaternion ();
			Instantiate (projectilePrefab[currentAmmo], projectileSpawn.position, projectileSpawn.rotation);
		}
	} 

}
