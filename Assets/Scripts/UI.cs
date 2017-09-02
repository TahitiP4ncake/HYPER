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

	// Use this for initialization
	void Start () 
	{
		playerSorts.Clear();

		foreach(Player _player in players)
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
			playerSorts [i].player.currentPosition = i+1;
		}

	}

}
