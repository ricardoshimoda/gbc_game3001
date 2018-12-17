using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurprisePhoto : MonoBehaviour {

	public Sprite[] photos;
	public Image teamImage;

	int currentImage;

	// Use this for initialization
	void Start () {
		currentImage = Random.Range(0,photos.Length-1);
		teamImage.sprite = photos[currentImage];
		Invoke ("PhotoChange", 5);

	}
	
	void PhotoChange(){
		currentImage++;
		teamImage.sprite = photos[currentImage%photos.Length];
		Invoke ("PhotoChange", 5);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
