using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SoundSettings : MonoBehaviour {

	public static float sfxVolume = 1.0f;
	public static float bgVolume = 1.0f;

	[SerializeField] Slider sfxSlider;
	[SerializeField] Slider bgSlider;
	

	// Use this for initialization
	void Start () {
		sfxSlider.value = sfxVolume;
		bgSlider.value = bgVolume;
	}
	
	public void ChangeSfxValue(float newValue){
		sfxVolume = newValue;
		Debug.Log("changing the sfx value to: "+newValue);
	}
	public void ChangeBgValue(float newValue){
		bgVolume = newValue;
		Debug.Log("changing the bg value to: "+newValue);
	}

	
}
