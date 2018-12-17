using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	[SerializeField] AudioClip ThankYou;
	[SerializeField] AudioClip Ouch;

	PlayerData playerData;

	bool active;

	int rocks;

	void Start () {
		var player = GameObject.FindGameObjectWithTag ("Hero");
		playerData = player.GetComponent<PlayerData> ();
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaySoundAndDeactivate(AudioClip correctAudioClip, GameObject projectile){
		var aud = this.GetComponent<AudioSource> ();
		aud.clip = correctAudioClip;
		Destroy (projectile);
		aud.Play ();
		//gameObject.SetActive (false);
		Destroy (gameObject.transform.parent.gameObject, 1.2f);
		active = false;
	}

	void OnTriggerEnter(Collider other){
		if (active) {
			if (other.gameObject.tag == "Food") {
				playerData.DecreaseReputation ();
				//PlaySoundAndDeactivate(ThankYou, other.gameObject.transform.parent.gameObject);
				// Destroys the projectile
				Destroy (other.gameObject.transform.parent.gameObject);
			} else if (other.gameObject.tag == "Rock") {
				PlaySoundAndDeactivate(Ouch, other.gameObject.transform.parent.gameObject);
				// Destroys the projectile
				Destroy (other.gameObject.transform.parent.gameObject);
			} else if (other.gameObject.tag == "Hero") {
				PlaySoundAndDeactivate(Ouch, other.gameObject.transform.parent.gameObject);
				playerData.InstaDeath ();
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.collider.tag == "Hero"){
			playerData.InstaDeath ();
		}

	}

}
