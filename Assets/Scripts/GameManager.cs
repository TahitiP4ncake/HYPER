using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using XInputDotNetPure;

using FluffyUnderware.Curvy;

public class GameManager : MonoBehaviour
{
    public RawImage flash;
    bool flashed;
    
	public int nbrPlayer = 0;

	public List<Player> players = new List<Player>();

	public List<CurvySpline> splines = new List<CurvySpline>();


	public static GameManager instance = null;

	float speedByTime =0.01f;

	public int nbrOfLap = 20;

	public UI ui;

	public Timer timer;

    AudioSource a_win;
    AudioSource a_theme;

    public Text restartText;

    bool gameOver;

    GamepadManager manager;


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

    private void Start()
    {
        a_win = Harmony.SetSource("Win");
        a_theme = Harmony.SetSource("theme1");
        a_theme.loop = true;
        Harmony.Play(a_theme);
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
		Invoke("TrueRaceBegin",3.5f);
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

    private void Update()
    {
        if(gameOver)
        {
            if (manager.GetButtonDownAny("Start"))
            {
                Scene _scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(_scene.buildIndex);
               
            }
            
        }
    }

    IEnumerator SpeedTime()
	{
		yield return new WaitForSeconds(1);

		while (true)
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
        manager = GamepadManager.Instance;
        

        if(!flashed)
        StartCoroutine(FlashTimer());
        gameOver = true;


		foreach ( Player _player in players )
		{
			_player.naturalSpeed = 0;
			_player.canMove = false;
            //ui.WinText(_player.visual.gameObject.GetComponentInChildren<Renderer>().material.GetColor("_Player_Color"));
            ui.WinText();
		}
	}
    IEnumerator FlashTimer()
    {
        StartCoroutine(AskRestart());
        Harmony.Play(a_win);

        flashed = true;
        flash.color = new Color(1, 1, 1, 1);

        float _a = 1;
        while(flash.color.a>0)
        {
            flash.color = new Color(1, 1, 1, _a);
            _a -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator AskRestart()
    {
        yield return new WaitForSeconds(4f);
        restartText.gameObject.SetActive(true);
    }

  

}