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

    public CameraLerp cam;


    public GameObject pauseMenu;
    bool onPause;


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
        manager = GamepadManager.Instance;
    }


    public void AddPlayer(int _playerIndex, int _gpIndex)
	{
		if(nbrPlayer == 0)
		{
			ui.lapPanel.SetActive(true);
		}

		players [_playerIndex].gameObject.SetActive(true);

		players [_playerIndex].SetPlayer(_playerIndex, _gpIndex);

		nbrPlayer++;

		ui.SetPlayerUI();

	}
	
	public void StartRace()
	{
		timer.StartGame();
		Invoke("TrueRaceBegin",3.2f);
		ui.WaitForCompt();
	}

	void TrueRaceBegin()
	{
		StartCoroutine(SpeedTime());

		foreach ( Player _player in players )
		{
			_player.StartRace();
		}


	}

     void Update()
    {
        if(gameOver)
        {
            if (manager.GetButtonDownAny("Start"))
            {
                Scene _scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(_scene.buildIndex);
               
            }
            
        }



        if(manager.GetButtonDownAny("Start") )
        {
            switch (onPause)
            {
                case false:
                    StartCoroutine(PauseOn());
                    break;
                case true:
                    StartCoroutine(PauseOff());
                    break;
            }
            
        }

        if (manager.GetButtonDownAny("Y") && onPause)
        {
            Time.timeScale = 1;
            Scene _scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(_scene.buildIndex);
        }

        if (manager.GetButtonDownAny("Back") && onPause)
        {
            Application.Quit();
        }


    }

    IEnumerator SpeedTime()
	{
		yield return new WaitForSeconds(0.5f);

		foreach ( Player _player in players )
		{
			_player.AddSpeedTime(speedByTime);
		}

		while (true)
		{
			yield return new WaitForSeconds(1);

			foreach(Player _player in players)
			{
				_player.AddSpeedTime(speedByTime);
			}
            if (!gameOver)
            {
                cam.speed += .05f;
            }

		}
	}

	public void EndGame( )
	{
        manager = GamepadManager.Instance;
        

        if(!flashed)
        StartCoroutine(FlashTimer());
        gameOver = true;
        cam.speed = 1;

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

    IEnumerator PauseOn()
    {
        onPause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        a_theme.volume = .3f;
        a_theme.pitch = .8f;
        yield return null;
    }
    IEnumerator PauseOff()
    {
        onPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        a_theme.volume = 1f;
        a_theme.pitch = 1;
        yield return null;
    }
  

}