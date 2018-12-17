using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Food {
	Burger,
	Chips,
	Fries,
	Donut,
	HotDog,
	Pizza,
	Taco,
	Sushi,
	Satisfied

}

public class Craving{
	public Food item;
	public bool satisfied = false;
}