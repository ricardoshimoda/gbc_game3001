using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	int Stamina;
	int Reputation;
	int Money;
	bool active;

	void Start () {
		Stamina = 100;
		Reputation = 100;
		Money = 0;
		active = true;
	}
	
	void Update () {
		if (active) {
			VerifyGameOver ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Rock") {
			DecreaseStamina ();

		}
	}

	void VerifyGameOver(){
		if (Stamina == 0 || Reputation == 0) {			
			Destroy (gameObject, 2);
		}
	}

	public void DecreaseStamina(){
		var staminaLoss =  Random.Range (1, 10);
		Debug.Log ("StaminaLoss: " + staminaLoss);
		Stamina = Mathf.Clamp( Stamina - staminaLoss, 0, 100);
	}

	public void DecreaseReputation(){
		var reputationLoss = Random.Range (1, 10);
		Debug.Log ("ReputationLoss:" + reputationLoss);
		Reputation = Mathf.Clamp( Reputation - reputationLoss, 0, 100);
	}

	public void IncreaseReputation(){
		var reputationGain = Random.Range (1, 10);
		Debug.Log ("ReputationGain" + reputationGain);
		Reputation = Mathf.Clamp( Reputation + reputationGain, 0, 100);

	}

	public void IncreaseMoney(){
		var profit = Random.Range (5, 15);
		Debug.Log ("Profit" + profit);
		Money += profit;
	}

	public int GetStamina(){
		return Stamina;
	}

	public int GetReputation(){
		return Reputation;
	}
}
