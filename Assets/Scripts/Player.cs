﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.Curvy;

using XInputDotNetPure;

public class Player : MonoBehaviour {

	public x360_Gamepad gamepad;
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

	public GameObject visualsPrefab;

	PlayerVisuals visual;

	bool canMove = false;

	bool canSwitch = false;

	bool isMoving = false;

	bool goInner = false;

	bool isOnBonus = false;

	public bool canInterract = true;

	void Start()
	{
		manager = GamepadManager.Instance;

		gamepad = manager.GetGamepad(playerIndex+1);

		GameObject _go = Instantiate(visualsPrefab);

		visual = _go.GetComponent<PlayerVisuals>();

		visual.SetPlayer(gameObject, playerIndex);

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

		}
		else if (other.gameObject.tag == "Malus" && canMove)
		{
			StopAllCoroutines();
			StartCoroutine(Malus());
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



		if (_inner)
		{
			if(splineNumber == 0)
			{
				return;
			}
			visual.PlayAnimation(AnimationState.Left);

			Debug.Log("RIGHT");
		}
		else
		{
			if ( splineNumber == 3 )
			{
				return;
			}
			Debug.Log("LEFT");
			visual.PlayAnimation(AnimationState.Right);
		}

		ChangeSpline(_inner);

		

	}

	public void SetBack()
	{
		Debug.Log(gameObject.name + " set Back");

		ChangeSpline(!goInner);

	}

	// par devant par derriere
	void Pushing()
	{
		Debug.Log(gameObject.name + " push");

		visual.PlayAnimation(AnimationState.Back);

	}

	void Pushed()
	{
		Debug.Log(gameObject.name + " is pushed");

		visual.PlayAnimation(AnimationState.Front);

		StopAllCoroutines();
		StartCoroutine(Bonus());

	}

	// Update is called once per frame
	void Update () 
	{
		controller.Speed = Mathf.Lerp(controller.Speed, speed, Time.deltaTime);

		if ( gamepad.GetButtonDown("A") )
		{
			if(isOnBonus && canMove)
			{
				isOnBonus = false;
				StopAllCoroutines();
				StartCoroutine(Bonus());
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
		bonusSpeed = 2f;
		SpeedCalcul();
		Debug.Log("BOOST");

		visual.PlayAnimation(AnimationState.Bonus);

		yield return new WaitForSeconds(2);
		Debug.Log("END BOOST");
		bonusSpeed = 1f;
		SpeedCalcul();
	}

	IEnumerator Malus()
	{
		bonusSpeed = 0.5f;
		SpeedCalcul();

		visual.PlayAnimation(AnimationState.Malus);

		yield return new WaitForSeconds(2);
		bonusSpeed = 1f;
		SpeedCalcul();
	}
}
