using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FluffyUnderware.Curvy;

public class GameManager : MonoBehaviour
{
	public int nbrPlayer = 0;

	public List<Player> players = new List<Player>();

	public List<CurvySpline> splines = new List<CurvySpline>();


	public static GameManager instance = null;

	float speedByTime =0.01f;

	public int nbrOfLap = 20;

	public UI ui;

	public Timer timer;

	AudioSource _audioSource;

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

	public void AddPlayer(int _playerIndex, int _gpIndex)
	{
		players [_playerIndex].gameObject.SetActive(true);

		players [_playerIndex].SetPlayer(_playerIndex, _gpIndex);

		nbrPlayer++;

		ui.SetPlayerUI();

	}
	
	public void StartRace()
	{
		timer.StartGame();
		Invoke("TrueRaceBegin",3);
		ui.WaitForCompt();
	}

	void TrueRaceBegin()
	{
		

		foreach ( Player _player in players )
		{
			_player.StartRace();
		}

		StartCoroutine(SpeedTime());
	}
	

	IEnumerator SpeedTime()
	{
		while(true)
		{
			yield return new WaitForSeconds(1);

			foreach(Player _player in players)
			{
				_player.AddSpeedTime(speedByTime);
			}

		}
	}

	public void EndGame( )
	{
		foreach ( Player _player in players )
		{
			_player.naturalSpeed = 0;
			_player.canMove = false;
			ui.WinText();
		}
	}

}