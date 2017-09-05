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

    public PlayerVisuals visuals;

	public Text lapCompteur;

	public Animator arrowRight;

	public Animator arrowLeft;

	bool canChangeLap = true;

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

		canChangeLap = true;

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

		if(canChangeLap)
		{
			if(GamepadManager.Instance.GetButtonDownAny("X"))
			{
				AddTurn(true);
			}
			else if(GamepadManager.Instance.GetButtonDownAny("B"))
			{
				AddTurn(false);
			}


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
		canChangeLap = false;
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
        switch(_winner)
        {
            case 0:
                winText.color = visuals.color1;
                winText.GetComponent<Shadow>().effectColor = new Color(visuals.color1.r, visuals.color1.g, visuals.color1.b, 7.5f);
                break;
            case 1:
                winText.color = visuals.color2;
                winText.GetComponent<Shadow>().effectColor = new Color(visuals.color2.r, visuals.color2.g, visuals.color2.b, 7.5f);
                break;
            case 2:
                winText.color = visuals.color3;
                winText.GetComponent<Shadow>().effectColor = new Color(visuals.color3.r, visuals.color3.g, visuals.color3.b, 7.5f);
                break;
            case 3:
                winText.color = visuals.color4;
                winText.GetComponent<Shadow>().effectColor = new Color(visuals.color4.r, visuals.color4.g, visuals.color4.b, 7.5f);
                break;
        }
        //winText.color = _color;
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

	void AddTurn(bool _add)
	{
		arrowLeft.SetTrigger("Move");
		arrowRight.SetTrigger("Move");

		if (_add)
		{
			GameManager.instance.nbrOfLap++;

			if(GameManager.instance.nbrOfLap>99)
			{
				GameManager.instance.nbrOfLap = 1;
			}

		}
		else
		{
			GameManager.instance.nbrOfLap--;

			if ( GameManager.instance.nbrOfLap < 1 )
			{
				GameManager.instance.nbrOfLap = 99;
			}
		}



	}


}
