using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	int Stamina;
	int Reputation;
	int Money;
	bool active;

	HUDManager HUDMgr;

	void Start () {
		Stamina = 100;
		Reputation = 100;
		Money = 50;
		active = true;
		GameObject HUD = GameObject.FindGameObjectWithTag("HUD");
		HUDMgr = HUD.GetComponent<HUDManager>();
		HUDMgr.ChangePlayerMoney(Money);

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
		if (Stamina == 0 || Reputation == 0 || Money == 0) {		
			Destroy (gameObject, 2);
		}
	}

	public bool IsGameOver(){
		return Stamina == 0 || Reputation == 0 || Money <= 0;
	}

	public void DecreaseStamina(){
		var staminaLoss =  Random.Range (1, 10);
		Stamina = Mathf.Clamp( Stamina - staminaLoss, 0, 100);
		HUDMgr.ChangePlayerStamina(Stamina);
	}

	public void DecreaseReputation(){
		var reputationLoss = Random.Range (1, 10);
		Reputation = Mathf.Clamp( Reputation - reputationLoss, 0, 100);
		HUDMgr.ChangePlayerReputation(Reputation);
	}

	public void IncreaseReputation(){
		var reputationGain = Random.Range (1, 10);
		Reputation = Mathf.Clamp( Reputation + reputationGain, 0, 100);
		HUDMgr.ChangePlayerReputation(Reputation);
	}

	public void UpdateMoney(int Amount){
		if(Amount > 0){
			float tip = Random.Range ((float)Amount*0.10f, (float)Amount*0.3f);
			Money += (int)Mathf.Floor(tip);
		}
		Money += Amount;
		if(Money < 0) Money = 0; /* Game Over... */
		HUDMgr.ChangePlayerMoney(Money);
	}

	public int GetStamina(){
		return Stamina;
	}

	public int GetReputation(){
		return Reputation;
	}

	public int GetMoney(){
		return Money;
	}
}
