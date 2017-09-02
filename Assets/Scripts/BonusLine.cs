using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLine : MonoBehaviour {

	public List<GameObject> bonus = new List<GameObject>();
	private List<int> bonusAlea = new List<int>();

	int alea;

	public bool isBonus;

	// Use this for initialization
	void Start () 
	{
		Randomize();
	}
	
	public void Randomize()
	{
		if ( bonusAlea.Count == 0 )
		{
			Refill();
		}

		alea = Random.Range(0, bonusAlea.Count);

		foreach(GameObject _go in bonus)
		{
			_go.SetActive(false);
		}

		bonus [alea].SetActive(true);

		bonusAlea.RemoveAt(alea);

		
	}

	void Refill()
	{
		for(int i = 0; i<bonus.Count; i++)
		{
			bonusAlea.Add(i);
		}
	}

}
