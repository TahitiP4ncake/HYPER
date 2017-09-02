using System.Collections;
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

	private float naturalSpeed = 5;

	private float splineSpeed;

	private float boosterSpeed = 1;

	private float timeSpeed = 1;

	private float calculSpeed;

	#endregion

	public GameObject visualsPrefab;

	PlayerVisuals visual;

	bool canSwitch = false;

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
	}

	public void ChangeSpline(bool _inner)
	{
		if(_inner)
		{
			if(splineNumber ==0)
			{
				return;
			}

			splineNumber--;

			controller.SwitchTo(GameManager.instance.splines[splineNumber], controller.RelativePosition, 0.1f);

		}
		else
		{
			if ( splineNumber == 3 )
			{
				return;
			}

			splineNumber++;

			controller.SwitchTo(GameManager.instance.splines [splineNumber], controller.RelativePosition, 0.1f);
		}

		SpeedCalcul();

	}

	void SpeedCalcul()
	{
		splineSpeed = 1.0f + ( (3.0f - splineNumber)/100.0f);

		calculSpeed = naturalSpeed * splineSpeed * timeSpeed;

		calculSpeed *= boosterSpeed;

		speed = calculSpeed;
	}

	public void AddSpeedTime(float _addSpeed)
	{
		timeSpeed += _addSpeed;

		SpeedCalcul();
	}

	public void AddBonus(float _bonus)
	{
		boosterSpeed = 1 + _bonus;
	}

	public void AddMalus(float _malus)
	{
		boosterSpeed = 1 - _malus;
	}

	// Update is called once per frame
	void Update () 
	{
		controller.Speed = Mathf.Lerp(controller.Speed, speed, Time.deltaTime);

		if ( gamepad.GetButtonDown("A") )
		{
			Debug.Log("oui");
		}

		if ( canSwitch )
		{

			if ( gamepad.GetStick_L().X >= 0.9f )
			{
				ChangeSpline(false);
				canSwitch = false;
			}

			if ( gamepad.GetStick_L().X <= -0.9f )
			{
				ChangeSpline(true);
				canSwitch = false;
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
}
