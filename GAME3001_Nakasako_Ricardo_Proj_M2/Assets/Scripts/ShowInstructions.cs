using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInstructions : MonoBehaviour {

	[SerializeField]GameObject pnlInstructions;

	public void DoShowInstructions()
	{
		pnlInstructions.SetActive (true);
	}
}
