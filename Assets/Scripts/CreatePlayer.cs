using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour {

    private GamepadManager manager;

    public x360_Gamepad gamepad1;
    public x360_Gamepad gamepad2;
    public x360_Gamepad gamepad3;
    public x360_Gamepad gamepad4;

    bool p1;
    bool p2;
    bool p3;
    bool p4;

    public Text pressStart;

	bool isLaunched = false;

    public int playerActive;

	bool canCheck = false;

	// Use this for initialization
	void Start( ) 
	{
		Invoke("CheckControllers", 0.1f);
        pressStart.gameObject.SetActive(false);
    }

	void CheckControllers()
	{ 

        manager = GamepadManager.Instance;

        switch(manager.ConnectedTotal())
        {
            case 1:
                gamepad1 = manager.GetGamepad(1);
                break;
            case 2:
                gamepad1 = manager.GetGamepad(1);
                gamepad2 = manager.GetGamepad(2);
				break;
            case 3:
                gamepad1 = manager.GetGamepad(1);
                gamepad2 = manager.GetGamepad(2);
                gamepad3 = manager.GetGamepad(3);
				break;
            case 4:
                gamepad1 = manager.GetGamepad(1);
                gamepad2 = manager.GetGamepad(2);
                gamepad3 = manager.GetGamepad(3);
                gamepad4 = manager.GetGamepad(4);
				break;
        } 
        canCheck = true;

	}
	
    void SetPlayer(int _playerIndex, int _gamepadIndex)
    {
		playerActive++;

		GameManager.instance.AddPlayer(_playerIndex, _gamepadIndex);
    }

	// Update is called once per frame
	void Update () {

		if ( isLaunched == true  )
		{

			return;
		}

		if( canCheck ==false)
		{
			return;
		}
		
        CheckGamepad();
		
		if ( playerActive > 1 )
		{
            if (!pressStart.gameObject.activeInHierarchy)
            {
                pressStart.gameObject.SetActive(true);
            }
			if ( manager.GetButtonDownAny("Start") )
			{
				
				LaunchRace();
			}
		}
	}

	void LaunchRace()
	{

        pressStart.text = "";
		isLaunched = true;
		GameManager.instance.StartRace();
	}

    void CheckGamepad()
    {
        switch (playerActive)
        {
            case 0:
				if(gamepad1!=null)
                if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    SetPlayer(0, 1);
                }
				if ( gamepad2 != null )
					if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    SetPlayer(0, 2);
                }
				if ( gamepad3 != null )
					if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    SetPlayer(0, 3);
                }
				if ( gamepad4 != null )
					if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    SetPlayer(0, 4);
                }
                break;
            case 1:
				if ( gamepad1 != null )
					if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    SetPlayer(1, 1);
                }
				if ( gamepad2 != null )
					if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    SetPlayer(1, 2);
                }
				if ( gamepad3 != null )
					if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    SetPlayer(1, 3);
                }
				if ( gamepad4 != null )
					if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    SetPlayer(1, 4);
                }
                break;
            case 2:
				if ( gamepad1 != null )
					if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    SetPlayer(2, 1);
                }
				if ( gamepad2 != null )
					if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    SetPlayer(2, 2);
                }
				if ( gamepad3 != null )
					if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    SetPlayer(2, 3);
                }
				if ( gamepad4 != null )
					if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    SetPlayer(2, 4);
                }
                break;
            case 3:
				if ( gamepad1 != null )
					if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    SetPlayer(3, 1);
					LaunchRace();

				}
				if ( gamepad2 != null )
					if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    SetPlayer(3, 2);
					LaunchRace();

				}
				if ( gamepad3 != null )
					if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    SetPlayer(3, 3);
					LaunchRace();

				}
				if ( gamepad4 != null )
					if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true; ;
					LaunchRace();

				}
                break;
        }
    }
}
