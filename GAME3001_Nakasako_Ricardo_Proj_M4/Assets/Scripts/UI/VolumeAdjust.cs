using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameAudioType{
	SoundFx,
	BgMusic
}

public class VolumeAdjust : MonoBehaviour {

	[SerializeField] GameAudioType myType;

	AudioSource noisySource;
	// Use this for initialization
	void Start () {
		noisySource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(myType == GameAudioType.SoundFx)
			noisySource.volume = SoundSettings.sfxVolume;
		else 
			noisySource.volume = SoundSettings.bgVolume;
		
	}
}
