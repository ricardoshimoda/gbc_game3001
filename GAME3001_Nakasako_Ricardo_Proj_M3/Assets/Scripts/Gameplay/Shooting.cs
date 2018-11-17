using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	[SerializeField] GameObject[] projectilePrefab; // Prefab to create the projectile
	[SerializeField] Transform projectileSpawn; // Where the projectile is instantiated
	[SerializeField] AudioClip[] gunEffects;
	[SerializeField] GameObject currentPlayer;
	int currentAmmo = 0;

	HUDManager HUDMgr;
	AudioSource aud;
	PlayerData currentPlayerData;
	bool upgrade = false;

	// Use this for initialization
	void Start () {
		GameObject HUD = GameObject.FindGameObjectWithTag("HUD");
		HUDMgr = HUD.GetComponent<HUDManager>();

		AudioSource[] childComponents = GetComponentsInChildren<AudioSource>();
		for(int i = 0; i < childComponents.Length; i++){
			if(childComponents[i].name == "BurgerGatling"){
				aud = childComponents[i];
			}
		}

		currentPlayerData = currentPlayer.GetComponent<PlayerData>();
		Debug.Log(currentPlayerData);
	}
	
	// Update is called once per frame
	void Update () {
		ChangeAmmo ();
		FireInput ();
	}

	void GunSound(int situation){
		aud.clip = gunEffects[situation];
		aud.Play();
	}



	void ChangeAmmo(){
		if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.Alpha1) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 0); 
			currentAmmo = 0;
		} else if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown (KeyCode.Alpha2) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 1); 
			currentAmmo = 1;
		} else if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown (KeyCode.Alpha3) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 2); 
			currentAmmo = 2;
		} else if (Input.GetKeyDown (KeyCode.Keypad4) || Input.GetKeyDown (KeyCode.Alpha4) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 3); 
			currentAmmo = 3;
		} else if (Input.GetKeyDown (KeyCode.Keypad5) || Input.GetKeyDown (KeyCode.Alpha5) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 4); 
			currentAmmo = 4;
		} else if (Input.GetKeyDown (KeyCode.Keypad6) || Input.GetKeyDown (KeyCode.Alpha6) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 5); 
			currentAmmo = 5;
		} else if (Input.GetKeyDown (KeyCode.Keypad7) || Input.GetKeyDown (KeyCode.Alpha7) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 6); 
			currentAmmo = 6;
		} else if (Input.GetKeyDown (KeyCode.Keypad8) || Input.GetKeyDown (KeyCode.Alpha8) ) {
			GunSound(1);
			HUDMgr.ChangeAmmo(currentAmmo, 7); 
			currentAmmo = 7;
		} 
	}


	void FireInput ()
	{
		if (Input.GetMouseButtonDown (0)) {
			GunSound(0);
			GameObject currentProjectile = Instantiate (projectilePrefab[currentAmmo], projectileSpawn.position, projectileSpawn.rotation);
			Projectile ammo = currentProjectile.GetComponent<Projectile>();
			if(ammo == null)
				ammo = currentProjectile.GetComponentInChildren<Projectile>();
			Debug.Log(ammo);
			currentPlayerData.UpdateMoney(-1 * ammo.cost);
		}
	} 

}
