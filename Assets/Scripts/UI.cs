using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

using UnityEngine.UI;

public class playerSort
{
	public int playerIndex;
	public Player player;
	public float turns;
}

public class UI : MonoBehaviour {

	public List<Player> players = new List<Player>();

	public List<Text> scores = new List<Text>();

	public List<Text> playerNumbers = new List<Text>();

	public List<Text> laps = new List<Text>();

	public List<Text> pressAs = new List<Text>();

	public List<playerSort> playerSorts = new List<playerSort>();

	public List<GameObject> panels = new List<GameObject>();

	public GameObject pressAPanels;

	public Text winText;

	// Use this for initialization
	void Start () 
	{
		playerSorts.Clear();

		DisplayPressA();

		foreach (Player _player in players)
		{
			playerSort _sort = new playerSort();
			_sort.player = _player;
			_sort.playerIndex = _player.playerIndex;

			playerSorts.Add(_sort);
		}

	}
	


	// Update is called once per frame
	void Update () 
	{
	DefineRanking();

		for(int i = 0; i < players.Count; i++)
		{
			laps[i].text = players[i].turn.ToString() + " / " + GameManager.instance.nbrOfLap.ToString();

			scores [i].text = "#" + players [i].currentPosition.ToString();
		}

		
	}

	void DefineRanking()
	{
		foreach ( playerSort _player in playerSorts)
		{
			_player.turns = (float) _player.player.turn + (float) ( _player.player.controller.RelativePosition / 10 );
		}

		playerSorts.Sort(( player1, player2 ) => player1.turns.CompareTo(player2.turns));

		for(int i =0; i<playerSorts.Count; i++)
		{
			playerSorts [i].player.currentPosition = 4 - i;
		}

	}

	public void DisplayPressA()
	{
		pressAPanels.SetActive(true);

		foreach(GameObject _go in panels)
		{
			_go.SetActive(false);
		}

	}

	public void SetPlayerUI()
	{
		pressAs [GameManager.instance.nbrPlayer - 1].text = "PLAYER #" + GameManager.instance.nbrPlayer;
	}

	public void WaitForCompt()
	{
		pressAPanels.SetActive(false);
		Invoke("DisplayGamePanel", 4);
	}

	void DisplayGamePanel()
	{
		for(int i =0; i<GameManager.instance.nbrPlayer; i++)
		{
			panels [i].SetActive(true);
		}
	}

	public void WinText()
	{

		for ( int i = 0; i < GameManager.instance.nbrPlayer; i++ )
		{
			panels [i].SetActive(false);
		}

		int _winner = 0;
		foreach(Player _player in players)
		{
			if(_player.currentPosition == 1)
			{
				_winner = _player.playerIndex;
				break;
			}
		}
		winText.text = "Player " + (_winner+1).ToString() + " won";

		winText.gameObject.SetActive(true);

		Invoke("ShowResult", 3);
	}

	void ShowResult()
	{
		winText.gameObject.SetActive(false);

		for ( int i = 0; i < GameManager.instance.nbrPlayer; i++ )
		{
			panels [i].SetActive(true);
		}
	}
}
