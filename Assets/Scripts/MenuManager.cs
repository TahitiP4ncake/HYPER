﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public x360_Gamepad gamepad;
    private GamepadManager manager;

    int steps;

    public GameObject hyper1;
    Vector3 hyperT1;

    public GameObject hyper2;
    Vector3 hyperT2;

    public GameObject hyper3;
    Vector3 hyperT3;

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
        hyperT1 = hyper1.transform.localPosition;
        hyperT2 = hyper2.transform.localPosition;
        hyperT3 = hyper3.transform.localPosition;

        manager = GamepadManager.Instance;
        bonus.SetActive(false);
        malus.SetActive(false);
        tuto.SetActive(false);
        nextScene.gameObject.SetActive(false);
    }

    void Update() {

        hyper1.transform.localPosition = new Vector3(hyperT1.x + Random.Range(-3, 3), hyperT1.y + Random.Range(-3, 3));
        hyper2.transform.localPosition = new Vector3(hyperT2.x + Random.Range(-2, 2), hyperT2.y + Random.Range(-2, 2));
        hyper3.transform.localPosition = new Vector3(hyperT3.x + Random.Range(-1, 1), hyperT3.y + Random.Range(-1, 1));

        if (manager.GetButtonDownAny("Start") && steps == 0)
        {
            Tuto();
            son.PlayOneShot(validation,1);
            //print("tuto");
            steps = 1;
            Invoke("BeforeStart", 2);  
        }

        if (manager.GetButtonDownAny("A") && steps == 2)
        {
            steps = 3;
            //print("start");
            StartGame();
        }

    }

    void BeforeStart()
        {
        //print("ready");
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
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(1);
    }
}
