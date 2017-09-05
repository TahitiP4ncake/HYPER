using System.Collections;
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

	public Controls goInnerDirection = Controls.Up;
	public Controls goOutterDirection = Controls.Down;

    bool jetOn;

    #region AudioSources

    AudioSource a_bonus;
    AudioSource a_malus;
    AudioSource a_impact;
    AudioSource a_spawn;
    AudioSource a_turn;

    #endregion

    void Start()
	{
		manager = GamepadManager.Instance;

        a_bonus = Harmony.SetSource("boost");
        a_malus = Harmony.SetSource("malus");
        a_impact = Harmony.SetSource("Player_Bump");
        a_turn = Harmony.SetSource("bipTour");
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
			bonus = other.gameObject.GetComponent<Bonus>();

			Harmony.Play(a_malus);

            GameObject _malus = Instantiate(malusFx, transform.position, malusFx.transform.rotation);
            Destroy(_malus, 1);

            StopAllCoroutines();
			StartCoroutine(Malus());

		}
		else if( other.gameObject.tag == "ChangeDirection" )
		{
			goInnerDirection = other.gameObject.GetComponent<ChangeDirection>().goInner;
			goOutterDirection = other.gameObject.GetComponent<ChangeDirection>().goOuter;
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

		visual.PlayAnimation(AnimationState.Back);
		gamepad.AddRumble(1, Vector2.one, 1);
	}

	void Pushed()
	{
        Harmony.Play(a_impact);
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

		controller.Speed = speed;

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

				switch ( goInnerDirection )
				{	
					case Controls.Left:
						if ( gamepad.GetStick_L().X <= -0.5f )
						{
							goInner = true;
							ChangeSpline(goInner);
							canSwitch = false;
						}
						break;
					case Controls.Right:
						if ( gamepad.GetStick_L().X >= 0.5f )
						{
							goInner = true;
							ChangeSpline(goInner);
							canSwitch = false;
						}
						break;
					case Controls.Up:
						if ( gamepad.GetStick_L().Y >= 0.5f )
						{
							goInner = true;
							ChangeSpline(goInner);
							canSwitch = false;
						}
						break;
					case Controls.Down:
						if ( gamepad.GetStick_L().Y <= -0.5f )
						{
							goInner = true;
							ChangeSpline(goInner);
							canSwitch = false;
						}
						break;
				}

				switch ( goOutterDirection )
				{
					case Controls.Left:
						if ( gamepad.GetStick_L().X <= -0.5f )
						{
							goInner = false;
							ChangeSpline(goInner);
							canSwitch = false;
						}
						break;
					case Controls.Right:
						if ( gamepad.GetStick_L().X >= 0.5f )
						{
							goInner = false;
							ChangeSpline(goInner);
							canSwitch = false;

						}
						break;
					case Controls.Up:
						if ( gamepad.GetStick_L().Y >= 0.5f )
						{
							goInner = false;
							ChangeSpline(goInner);
							canSwitch = false;
						}
							break;
					case Controls.Down:
						if ( gamepad.GetStick_L().Y <= -0.5f )
						{
							goInner = false;
							ChangeSpline(goInner);
							canSwitch = false;
						}
						break;
				}

			

				
			}
		}
		else
		{
			if(goInnerDirection== Controls.Left || goInnerDirection == Controls.Right)
			{
				if ( gamepad.GetStick_L().X < 0.5f && gamepad.GetStick_L().X > -0.5f )
				{
					canSwitch = true;
				}
			}

			if ( goInnerDirection == Controls.Up || goInnerDirection == Controls.Down )
			{
				if (gamepad.GetStick_L().Y <= 0.5f && gamepad.GetStick_L().Y >= -0.5f )
				{
					canSwitch = true;
				}
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
        jetOn = true;
        
		bonusSpeed = 2f;

		if(currentPosition-1!=0)
		{
			bonusSpeed += ( (float) currentPosition - 1 )/2;
		}
		
		bonusSpeed += ((float)currentPosition -1);

		SpeedCalcul();

		gamepad.AddRumble(0.5f, Vector2.one, 1);


		visual.PlayAnimation(AnimationState.Bonus);

		yield return new WaitForSeconds(2);

		bonusSpeed = 1f;
        visual.JetOff();
        jetOn = false;
        SpeedCalcul();
	}

	IEnumerator Malus()
	{
        visual.JetOff();
        gamepad.AddRumble(1, Vector2.one, 1);

		if(bonus==null)
		{
			
		}

		bonus.Randomize();

		bonusSpeed = 0.5f - ((float)currentPosition/10);
		SpeedCalcul();

		visual.PlayAnimation(AnimationState.Malus);

		yield return new WaitForSeconds(2);
		bonusSpeed = 1f;
		SpeedCalcul();
	}

	public void AddTurn()
	{
        Harmony.Play(a_turn);

		turn++;


		if (turn >= GameManager.instance.nbrOfLap)
		{
			GameManager.instance.EndGame();
		}

	}


}
