using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

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

    public int playerActive;
    // Use this for initialization
    void Start () {
        manager = GamepadManager.Instance;
        switch(manager.actif)
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
        gamepad1 = manager.GetGamepad(1);
    }
	
	// Update is called once per frame
	void Update () {
        CheckGamepad();
	}

    void CheckGamepad()
    {
        switch (playerActive)
        {
            case 0:
                if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    //instantiate
                }
                if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    //instantiate
                }
                if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    //instantiate
                }
                if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    //instantiate
                }
                break;
            case 1:
                if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    //instantiate
                }
                if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    //instantiate
                }
                if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    //instantiate
                }
                if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    //instantiate
                }
                break;
            case 2:
                if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    //instantiate
                }
                if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    //instantiate
                }
                if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    //instantiate
                }
                if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    //instantiate
                }
                break;
            case 3:
                if (gamepad1.GetButtonDown("A") && !p1)
                {
                    p1 = true;
                    //instantiate
                }
                if (gamepad2.GetButtonDown("A") && !p2)
                {
                    p2 = true;
                    //instantiate
                }
                if (gamepad3.GetButtonDown("A") && !p3)
                {
                    p3 = true;
                    //instantiate
                }
                if (gamepad4.GetButtonDown("A") && !p4)
                {
                    p4 = true;
                    //instantiate
                }
                break;
        }
    }
}
