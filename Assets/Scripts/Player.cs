using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.Curvy;

public class Player : MonoBehaviour {

	public Rigidbody rigid;

	public SplineController controller;

	private int splineNumber;

	public int playerIndex;

	public float speed=0;

	private float naturalSpeed = 5;

	private float splineSpeed;

	private float boosterSpeed = 1;

	private float timeSpeed = 1;

	private float calculSpeed;

	public GameObject visualsPrefab;

	PlayerVisuals visual;


	void Start()
	{
		GameObject _go = Instantiate(visualsPrefab);

		visual = _go.GetComponent<PlayerVisuals>();

		visual.SetPlayer(gameObject, playerIndex);

	}



	public void StartRace()
	{

		splineNumber = playerIndex;

		SpeedCalcul();


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



	}

	void SpeedCalcul()
	{
		splineSpeed = 1.0f + ( (3.0f - splineNumber)/100.0f);

		Debug.Log(splineSpeed);

		calculSpeed = naturalSpeed * splineSpeed * timeSpeed;

		calculSpeed *= boosterSpeed;

		speed = calculSpeed;

		//controller.Speed = speed;
	}

	// Update is called once per frame
	void Update () 
	{
		controller.Speed = Mathf.Lerp(controller.Speed, speed, Time.deltaTime);

		if ( rigid != null )
		{
			Debug.Log(rigid.velocity.magnitude);
		}
	}
}
