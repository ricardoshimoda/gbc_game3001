using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {


	[SerializeField] AudioClip ThankYou;
	[SerializeField] AudioClip Ouch;

	bool active;

	// Use this for initialization
	void Start () {
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
		Destroy (gameObject, 1.2f);
		active = false;
	}


	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.tag);
		if (active) {
			var player = GameObject.FindGameObjectWithTag ("Hero");
			var playerData = player.GetComponent<PlayerData> ();
			if (other.gameObject.tag == "Food") {
				playerData.IncreaseReputation ();
				playerData.IncreaseMoney ();
				PlaySoundAndDeactivate (ThankYou, other.gameObject.transform.parent.gameObject);
			} else if (other.gameObject.tag == "Rock") {
				playerData.DecreaseReputation ();
				PlaySoundAndDeactivate (Ouch, other.gameObject.transform.parent.gameObject);
			} else if (other.gameObject.tag == "Hero") {
				PlaySoundAndDeactivate(Ouch, other.gameObject.transform.parent.gameObject);
				playerData.DecreaseStamina ();
			}
		}
	}
}
