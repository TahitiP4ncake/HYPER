using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FluffyUnderware.Curvy;

public class GameManager : MonoBehaviour
{
	private int nbrPlayer = 4;

	public List<Player> players = new List<Player>();

	public List<CurvySpline> splines = new List<CurvySpline>();


	public static GameManager instance = null;

	void Awake( )
	{
		//Check if instance already exists
		if ( instance == null )

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if ( instance != this )
		{

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}
	}

	void Start()
	 {
		foreach(Player _player in players)
		{
			_player.StartRace();
		}
	 }


}