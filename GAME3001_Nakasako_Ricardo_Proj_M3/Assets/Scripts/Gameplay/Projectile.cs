using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float projectileSpeed;
	[SerializeField] float disappearTime; 
	[SerializeField] public Food[] content;
	[SerializeField] public int cost;
	[SerializeField] public int sell;
	[SerializeField] GameObject root;

	Rigidbody rig;

	// Use this for initialization
	void Start () {
		Destroy (root, disappearTime);
		rig = this.GetComponentInChildren<Rigidbody> ();
		rig.AddForce (transform.forward * projectileSpeed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Zombie" || 
			other.gameObject.tag == "Customer" ||
			other.gameObject.tag == "Rock" ) {
			Destroy (root);
		}
	}

	void OnCollisionEnter(Collision point){
	}

}
