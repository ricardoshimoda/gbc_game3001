using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {

	[SerializeField] AudioClip thankYou;
	[SerializeField] AudioClip ouch;
	[SerializeField] Food[] cravings;
	bool active;
	int payment;

	// Use this for initialization
	void Start () {
		active = true;
		payment = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	void PlaySoundAndDeactivate(AudioClip correctAudioClip){
		var aud = this.GetComponent<AudioSource> ();
		aud.clip = correctAudioClip;
		aud.Play ();
		//Debug.Log("Play the sound, dammit!");
		Destroy (gameObject.transform.parent.gameObject, 1.2f);
		active = false;
	}


	void OnTriggerEnter(Collider other){
		if (active) {
			var player = GameObject.FindGameObjectWithTag ("Hero");
			var playerData = player.GetComponent<PlayerData> ();
			if (other.gameObject.tag == "Food" || other.gameObject.tag == "Combo") {
				Projectile bullet = other.gameObject.GetComponent<Projectile>();
				if(bullet == null) bullet = other.gameObject.GetComponentInChildren<Projectile>();
				bool foundIt = false;
				for(int i = 0; i < bullet.content.Length; i++){
					for(int j = 0; j < cravings.Length; j++){
						if(cravings[j] == bullet.content[i]){
							foundIt = true;
							cravings[j] = Food.Satisfied;
							bullet.content[i] = Food.Satisfied; // Consumed...
							Debug.Log(bullet.sell);
							payment += bullet.sell;
						}
					}
				}
				bool completelySatisfied = true;
				for(int k = 0; k < cravings.Length; k++){
					if(cravings[k] != Food.Satisfied){
						completelySatisfied = false;
					}
				}
				if(completelySatisfied){
					playerData.IncreaseReputation ();
					playerData.UpdateMoney (payment);
					PlaySoundAndDeactivate (thankYou);
				}
			} else if (other.gameObject.tag == "Rock") {
				playerData.DecreaseReputation ();
				PlaySoundAndDeactivate (ouch);
			} else if (other.gameObject.tag == "Hero") {
				PlaySoundAndDeactivate(ouch);
				playerData.DecreaseStamina ();
			}
		}
	}
}
