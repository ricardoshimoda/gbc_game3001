using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	[SerializeField] string levelToLoad;

	public void Start(){
		 Cursor.lockState = CursorLockMode.None;
		 Cursor.visible = true;
	}

	public void DoSceneChange()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}
