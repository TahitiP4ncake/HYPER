using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;

    public bool gameOn;

    public AnimationCurve sizeCurve;

    float timeStart;

    public AudioSource son;

    public AudioClip wait;
    public AudioClip go;

    Vector3 startSize;

	void Start () {
        timerText.text = "";
        startSize = timerText.transform.localScale;

        StartGame();

    }
	
	void Update ()
    {
        if (gameOn)
        {
            timeStart += Time.deltaTime;
            timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        }
	}

    public void StartGame()
    {
        gameOn = true;
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "3";

        son.PlayOneShot(wait);

        yield return new WaitForSeconds(1);
        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "2";

        son.pitch = 1.02f;
        son.PlayOneShot(wait);

        yield return new WaitForSeconds(1);
        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "1";

        son.pitch = 1.05f;
        son.PlayOneShot(wait);

        yield return new WaitForSeconds(1);
        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "GO";

        son.pitch = 1.1f ;
        son.PlayOneShot(wait);
        son.PlayOneShot(go);

        yield return new WaitForSeconds(1);
        timerText.text = "";
        gameOn = true;
    }
}