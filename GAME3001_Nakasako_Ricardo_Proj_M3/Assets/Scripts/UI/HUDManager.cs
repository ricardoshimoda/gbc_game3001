using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField] GameObject[] ammoPanels;
	[SerializeField] Sprite[] basicSprites;
	[SerializeField] Sprite[] comboSprites;
	[SerializeField] Image staminaBar;
	[SerializeField] Image reputationBar;
	[SerializeField] Text earnings;

	Color Unselected = new Color(1,1,1,0.5f);
	Color Selected = new Color(0,1,0,0.5f);

	public void ChangeAmmo(int currentAmmo, int nextAmmo){
		var newTrans = ammoPanels[currentAmmo].GetComponent<Image>();
		newTrans.color = Unselected;
		var newGreen = ammoPanels[nextAmmo].GetComponent<Image>();
		newGreen.color = Selected;
	}

	public void UpgradeFood(int upgradeAmmo){
		Image[] Icons = ammoPanels[upgradeAmmo].GetComponentsInChildren<Image>();
		for(int i = 0; i < Icons.Length; i++){
			if(Icons[i].name == "Icon"){
				Icons[i].sprite = comboSprites[upgradeAmmo];
				return;
			}
		}
	}

	public void DowngradeFood(int downgradeAmmo){
		Image[] Icons = ammoPanels[downgradeAmmo].GetComponentsInChildren<Image>();
		for(int i = 0; i < Icons.Length; i++){
			if(Icons[i].name == "Icon"){
				Icons[i].sprite = basicSprites[downgradeAmmo];
				return;
			}
		}
	}

	public void ChangePlayerStamina(int newStamina){
		var staminaText = staminaBar.GetComponentsInChildren<Text>()[0];
		staminaBar.fillAmount = (float)newStamina/100.0f;
		staminaText.text = newStamina + "/100";
	}

	public void ChangePlayerReputation(int newReputation){
		var reputationText = reputationBar.GetComponentsInChildren<Text>()[0];
		reputationBar.fillAmount = (float)newReputation/100.0f;
		reputationText.text = newReputation + "/100";
	}

	public void ChangePlayerMoney(int newMoney){
		earnings.text = newMoney.ToString();
	}
}
