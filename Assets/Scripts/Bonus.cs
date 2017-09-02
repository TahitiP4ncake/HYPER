using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

	public BonusLine bonusLine;

	public void Randomize()
	{
		bonusLine.Randomize();
	}	
	
}
