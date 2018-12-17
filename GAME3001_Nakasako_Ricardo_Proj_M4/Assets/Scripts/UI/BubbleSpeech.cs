using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSpeech : MonoBehaviour {
	
	[SerializeField] Canvas bubble;

	Transform playerTransform;
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Hero");
		playerTransform = player.transform;
	}
	void Update(){
		if(bubble.enabled){
			bubble.transform.rotation = playerTransform.rotation;
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Hero") {
			bubble.enabled=true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Hero") {
			bubble.enabled=false;
		}
	}
}
