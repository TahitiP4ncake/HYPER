﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.Curvy;

using XInputDotNetPure;

public class Player : MonoBehaviour {

	public x360_Gamepad gamepad = null;
	private GamepadManager manager;

	public Rigidbody rigid;

	public SplineController controller;

	private int splineNumber;

	public int playerIndex;

	#region Speed

	public float speed=0;

	public float naturalSpeed = 5;

	private float splineSpeed;

	private float bonusSpeed = 1;

	private float timeSpeed = 1;

	private float calculSpeed;

    #endregion

    public GameObject bonusFx;
    public GameObject malusFx;
    public GameObject impactFx;

	public GameObject visualsPrefab;

	public PlayerVisuals visual;
	public bool canMove = false;

	bool canSwitch = false;

	bool isMoving = false;

	bool goInner = false;

	bool isOnBonus = false;

	Bonus bonus;

	public bool canInterract = true;

	public int turn=0;

	public int currentPosition;

    #region AudioSources

    AudioSource a_bonus;
    AudioSource a_malus;
    AudioSource a_impact;
    AudioSource a_spawn;

    #endregion

    void Start()
	{
		manager = GamepadManager.Instance;

        a_bonus = Harmony.SetSource("boost");
        a_malus = Harmony.SetSource("malus");
        a_impact = Harmony.SetSource("Player_Bump");
        
	}


	public void SetPlayer(int _playerIndex, int _gpIndex)
	{
		playerIndex = _playerIndex;

		manager = GamepadManager.Instance;
		gamepad = manager.GetGamepad(_gpIndex);

		gamepad.AddRumble(1, Vector2.one, 0.5f);

		GameObject _go = Instantiate(visualsPrefab, transform.position,transform.rotation);

		visual = _go.GetComponent<PlayerVisuals>();

		visual.SetPlayer(gameObject, playerIndex);

        a_spawn = Harmony.SetSource("speed");
        Harmony.Play(a_spawn);
	}

	public void StartRace()
	{
		splineNumber = playerIndex;
		canSwitch = true;
		canMove = true;
	}

	public void ChangeSpline(bool _inner)
	{
		if( canInterract == false)
		{
			return;
		}

		if (_inner)
		{

			if(splineNumber ==0)
			{
				return;
			}

			goInner = true;

			splineNumber--;

			controller.SwitchTo(GameManager.instance.splines[splineNumber], controller.RelativePosition, 0.1f);

			isMoving = true;

			Invoke("StopMoving", 0.1f);

		}
		else
		{
			if ( splineNumber == 3 )
			{
				return;
			}

			goInner = false;

			splineNumber++;

			controller.SwitchTo(GameManager.instance.splines [splineNumber], controller.RelativePosition, 0.1f);


			isMoving = true;

			Invoke("StopMoving", 0.1f);
		}

		SpeedCalcul();

	}

	void SpeedCalcul()
	{
		splineSpeed = 1.0f + ( (3.0f - splineNumber)/100.0f);

		calculSpeed = naturalSpeed * splineSpeed * timeSpeed;

		calculSpeed += bonusSpeed*calculSpeed;

		speed = calculSpeed;
	}

	public void AddSpeedTime(float _addSpeed)
	{
		timeSpeed += _addSpeed;

		SpeedCalcul();
	}

	public void AddBonus(float _bonus)
	{
		bonusSpeed = 1 + _bonus;
	}

	public void AddMalus(float _malus)
	{
		bonusSpeed = 1 - _malus;
	}

	void StopMoving()
	{
		isMoving = false;
	}

	void OnTriggerEnter( Collider other )
	{
		if ( other.gameObject.tag == "Player" )
		{

			Player _player = other.gameObject.GetComponent<Player>();

			if ( isMoving )
			{
				if ( _player.isMoving == false )
				{
					_player.Collided(goInner);

					if ( ( goInner && splineNumber == 0 ) || ( !goInner && splineNumber == 3 ) )
					{
						SetBack();
					}
				}
			} // Je te rentre dedans par derriere
			else if ( isMoving == false && _player.isMoving == false )
			{
				if ( controller.RelativePosition > _player.controller.RelativePosition )
				{
                    GameObject _impactFx = Instantiate(impactFx, transform.position, impactFx.transform.rotation);
                    Destroy(_impactFx, 1);
                    Pushed();
				}
				else
				{
					Pushing();
				}
			}
		}
		else if(other.gameObject.tag == "Bonus")
		{
			isOnBonus = true;
			bonus = other.gameObject.GetComponent<Bonus>();
            
		}
		else if (other.gameObject.tag == "Malus" && canMove)

		{
            Harmony.Play(a_malus);

            GameObject _malus = Instantiate(malusFx, transform.position, malusFx.transform.rotation);
            Destroy(_malus, 1);

            StopAllCoroutines();
			StartCoroutine(Malus());
			bonus = other.gameObject.GetComponent<Bonus>();
		}
	}

	void OnTriggerExit( Collider other )
	{
		if ( other.gameObject.tag == "Bonus" )
		{
			isOnBonus = false;

		}
	}	


	// Coté
	public void Collided(bool _inner)
	{
		if(canMove==false)
		{
			return;
		}

		StopAllCoroutines();
		StartCoroutine(CooldowncanMove());

		gamepad.AddRumble(1, Vector2.one, 1);

		if (_inner)
		{
			if(splineNumber == 0)
			{
				return;
			}

            visual.PlayAnimation(AnimationState.Left);
		}
		else
		{
			if ( splineNumber == 3 )
			{
				return;
			}
            
            visual.PlayAnimation(AnimationState.Right);
		}
        Harmony.Play(a_impact);

        GameObject _impactFx = Instantiate(impactFx, transform.position, impactFx.transform.rotation);
        Destroy(_impactFx, 1);

        ChangeSpline(_inner);

	}

	public void SetBack()
	{
        Harmony.Play(a_impact);

        GameObject _impactFx = Instantiate(impactFx, transform.position, impactFx.transform.rotation);
        Destroy(_impactFx, 1);

        ChangeSpline(!goInner);

	}

	// par devant par derriere
	void Pushing()
	{
		Debug.Log(gameObject.name + " push");

		visual.PlayAnimation(AnimationState.Back);
		gamepad.AddRumble(1, Vector2.one, 1);
	}

	void Pushed()
	{
        Harmony.Play(a_impact);

        Debug.Log(gameObject.name + " is pushed");

		visual.PlayAnimation(AnimationState.Front);

		StopAllCoroutines();
		StartCoroutine(Bonus());

	}

	// Update is called once per frame
	void Update () 
	{
		if(gamepad==null)
		{
			return;
		}

		controller.Speed = Mathf.Lerp(controller.Speed, speed, Time.deltaTime);

		if ( gamepad.GetButtonDown("A") )
		{
			if(isOnBonus && canMove)
			{
                Harmony.Play(a_bonus);

                visual.PlayAnimation(AnimationState.Front);
                Instantiate(bonusFx,transform.position, bonusFx.transform.rotation);
                isOnBonus = false;
				StopAllCoroutines();
				StartCoroutine(Bonus());
				bonus.Randomize();
			}
		}

		if ( canSwitch )
		{
			if ( canMove )
			{
				if ( gamepad.GetStick_L().X >= 0.9f )
				{
					goInner = false;
					ChangeSpline(false);
					canSwitch = false;
					
				}

				if ( gamepad.GetStick_L().X <= -0.9f )
				{
					goInner = true;
					ChangeSpline(true);
					canSwitch = false;
					
				}
			}
		}
		else
		{
			if ( gamepad.GetStick_L().X <= 0.1f && gamepad.GetStick_L().X >= -0.1f )
			{
				canSwitch = true;
			}
		}
	}

	IEnumerator CooldowncanMove()
	{
		canMove = false;

		bonusSpeed = 0.5f;
		SpeedCalcul();

		yield return new WaitForSeconds(0.5f);

		bonusSpeed = 1f;
		SpeedCalcul();

		canMove = true;
	}

	IEnumerator Bonus()
	{
        visual.JetOn();
        bonusSpeed = 2f;
		SpeedCalcul();


		visual.PlayAnimation(AnimationState.Bonus);

		yield return new WaitForSeconds(2);

		bonusSpeed = 1f;
        visual.JetOff();
        SpeedCalcul();
	}

	IEnumerator Malus()
	{
        visual.JetOff();
        gamepad.AddRumble(1, Vector2.one, 1);

		bonus.Randomize();

		bonusSpeed = 0.5f;
		SpeedCalcul();

		visual.PlayAnimation(AnimationState.Malus);

		yield return new WaitForSeconds(2);
		bonusSpeed = 1f;
		SpeedCalcul();
	}

	public void AddTurn()
	{
		turn++;
		if(turn >= GameManager.instance.nbrOfLap)
		{
			GameManager.instance.EndGame();
		}
	}
}
