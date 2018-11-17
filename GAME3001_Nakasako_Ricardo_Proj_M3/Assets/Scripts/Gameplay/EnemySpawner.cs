using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] GameObject hero;
	[SerializeField] GameObject[] enemies;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", Random.Range(5,10));
	}

	void SpawnEnemy(){
		int whichEnemy = Random.Range (0, 1);
		/*
		Vector3 newEnemyPosition = new Vector3 (
			hero.transform.position.x + Random.Range (10, 30), 
			hero.transform.position.y, 
			hero.transform.position.z + Random.Range (10, 30));
		Instantiate (enemies[whichEnemy], newEnemyPosition, hero.transform.rotation);
		Invoke ("SpawnEnemy", Random.Range(5,10));
		 */
	}

}
