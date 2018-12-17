using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] GameObject hero;
	[SerializeField] GameObject[] enemies;
	[SerializeField] Transform[] spawnPoints;
	[SerializeField] float minTimeForNewEnemy;
	[SerializeField] float maxTimeForNewEnemy;
	PlayerData currentPlayer;


	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", Random.Range(minTimeForNewEnemy, maxTimeForNewEnemy));
		currentPlayer = hero.GetComponent<PlayerData>();
	}

	int EnemySelection(){
		int selectedEnemy = 0;
		int money = currentPlayer.GetMoney();
		if(money < 100){
			selectedEnemy = Random.Range(0,2);
		} else if(money < 200){
			selectedEnemy = Random.Range(0,4);
		} else if(money < 300){
			selectedEnemy = Random.Range(0,5);
		} else if (money < 500){
			selectedEnemy = Random.Range(0,6);
		} else{
			// this is the final event
			return -1;
		}
		return selectedEnemy;
	}

	int SpawnWhere(){
		int spawnIndex = Random.Range(0,14);
		float distanceFromPlayer = Vector3.Distance(spawnPoints[spawnIndex].position, hero.transform.position);
		while(distanceFromPlayer < 14.1){
			spawnIndex++;
			distanceFromPlayer = Vector3.Distance(spawnPoints[spawnIndex].position, hero.transform.position);
		}
		return spawnIndex;
	}


	void SpawnEnemy(){
		if(!currentPlayer.IsGameOver()){
			int whichEnemy = EnemySelection();
			int spawnPositon = SpawnWhere();
			if(whichEnemy != -1){
				Instantiate (enemies[whichEnemy], spawnPoints[spawnPositon].position, hero.transform.rotation);
				Invoke ("SpawnEnemy", Random.Range(minTimeForNewEnemy, maxTimeForNewEnemy));
			}else{
				Instantiate (enemies[6], spawnPoints[spawnPositon].position, hero.transform.rotation);
				Instantiate (enemies[7], spawnPoints[spawnPositon].position, hero.transform.rotation);
				Instantiate (enemies[6], spawnPoints[spawnPositon].position, hero.transform.rotation);
				//Invoke ("SpawnEnemy", Random.Range(minTimeForNewEnemy, maxTimeForNewEnemy));
			}
		}
	}

}
