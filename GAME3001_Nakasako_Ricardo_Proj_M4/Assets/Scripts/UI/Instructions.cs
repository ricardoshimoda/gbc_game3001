using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

	[SerializeField] Text instructionText;
	[SerializeField] Image instructionDisplay;

	[SerializeField] Sprite[] instructionImages;

	int currentSlide = 0;

	string[] instructionMessages = new string []
	{	
		"Are you ready to play the game?",
		"To move around use the keyboard keys WASD - to jump press the space bar and to shoot, press the left mouse button",
		"To change your 'serving' use the keyboard keys from 1 to 8",
		"Everytime a client approaches you, he/she is going to tell you what you should serve him/her",
		"Every time you shoot an ingredient you have to pay for it. If you take too long to serve, they might hit you, decreasing your stamina",
		"Every time you fill an order, you'll get money and your reputation will increase",
		"After reaching more than $120 in your pocket, your ingredients get upgraded to combos... as well as your enemies",
		"Policemen will never pay for their donuts - but its is better than having your reputation going down",
		"Zombies want brains... and they never give up - throw a rock or get away from them as they could end your business in just one bite"
	};

	// Use this for initialization
	void Start () {
		instructionText.text = instructionMessages[0];
		instructionDisplay.sprite = instructionImages[0];
		Invoke ("InstructionChange", 5);
	}
	
	// Update is called once per frame
	void InstructionChange () {
		currentSlide++;
		currentSlide = currentSlide%8;		
		instructionText.text = instructionMessages[currentSlide];
		instructionDisplay.sprite = instructionImages[currentSlide];
		Invoke ("InstructionChange", 5);
	}
}
