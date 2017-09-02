using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;

    public bool gameOn;

    public AnimationCurve sizeCurve;

    float timeStart;

    Vector3 startSize;

	void Start () {
        StartCoroutine(StartTimer());
        startSize = timerText.transform.localScale;
	}
	
	void Update () {
        
            timeStart += Time.deltaTime;
            timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        
	}

    public IEnumerator StartTimer()
    {
        
        print("1");
        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "3";
        yield return new WaitForSeconds(1);
        print("2");

        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "2";
        yield return new WaitForSeconds(1);
        print("3");

        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "1";
        yield return new WaitForSeconds(1);
        print("4");

        timeStart = 0;
        timerText.transform.localScale = startSize * sizeCurve.Evaluate(timeStart);
        timerText.text = "GO";
        yield return new WaitForSeconds(1);
        print("5");

        timerText.text = "";
        gameOn = true;
    }
}
