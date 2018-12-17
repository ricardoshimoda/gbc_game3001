using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour {

	int Stamina;
	int Reputation;
	int Money;
	bool active;
	bool upgraded = false;

	HUDManager HUDMgr;

	void Start () {
		Stamina = 100;
		Reputation = 100;
		Money = 110;
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
		if (other.gameObject.tag == "Rock2" || other.gameObject.tag == "Rock") {
			DecreaseStamina ();

		}
	}

	void VerifyGameOver(){
		if (Stamina == 0 ){
			SceneManager.LoadScene("Dead");
			return;
		}
		if(Reputation == 0){
			SceneManager.LoadScene("Failure");
			return;
		}
		if(Money == 0) {
			SceneManager.LoadScene("Bankrupt");
			return;
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Customer");
		if(enemies.Length == 0 && Money > 2000){
			SceneManager.LoadScene("HappyEnding");
			return;
		}
	}

	public bool IsGameOver(){
		return Stamina == 0 || Reputation == 0 || Money <= 0;
	}

	public void InstaDeath(){
		//Stamina = 0;
		//HUDMgr.ChangePlayerStamina(Stamina);
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
		if(Money > 120 && Amount > 0 && !upgraded){
			HUDMgr.UpgradeMenu();
			upgraded = true;
		}
		if(Money < 100 && Amount < 0 && upgraded){
			HUDMgr.DowngradeMenu();
			upgraded = false;
		}
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
	public bool GetUpgraded(){
		return upgraded;
	}
}
