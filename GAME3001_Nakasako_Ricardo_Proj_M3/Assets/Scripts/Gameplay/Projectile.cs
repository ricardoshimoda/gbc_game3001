using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float projectileSpeed;
	[SerializeField] float disappearTime; 
	Rigidbody rig;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, disappearTime);
		rig = this.GetComponentInChildren<Rigidbody> ();
		rig.AddForce (transform.forward * projectileSpeed);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Projectile Says: " + other.gameObject.tag);
		if (other.gameObject.tag == "Beggar" || 
			other.gameObject.tag == "Customer") {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision point){
	}

}
