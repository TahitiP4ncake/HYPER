using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public x360_Gamepad gamepad;
    private GamepadManager manager;

    int steps;

    public GameObject titre;
    public GameObject tuto;
    public GameObject bonus;
    public GameObject malus;
    public Text nextScene;

    public AudioSource son;

    public AudioClip validation;
    public AudioClip start;

    void Start()
    {
        manager = GamepadManager.Instance;
        bonus.SetActive(false);
        malus.SetActive(false);
        tuto.SetActive(false);
        nextScene.gameObject.SetActive(false);
    }

    void Update() {

        if (manager.GetButtonDownAny("Start") && steps == 0)
        {
            Tuto();
            son.PlayOneShot(validation,1);
            print("tuto");
            steps = 1;
            Invoke("BeforeStart", 2);  
        }

        if (manager.GetButtonDownAny("A") && steps == 2)
        {
            steps = 3;
            print("start");
            StartGame();
        }

    }

    void BeforeStart()
        {
        print("ready");
        nextScene.gameObject.SetActive(true);
        steps = 2;
    }

    void Tuto()
    {
        titre.SetActive(false);
        tuto.SetActive(true);
        bonus.SetActive(true);
        malus.SetActive(true);
    }

    void StartGame()
    {
        son.pitch = 1.1f;
        son.PlayOneShot(start,1);
        print("LOAD SCENE");
        //SceneManager.LoadScene(1);
    }
}
