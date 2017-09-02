using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;

    public bool gameOn = true;

    public AnimationCurve sizeCurve;

    float timeStart;

    Vector3 startSize;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartTimer());

        startSize = timerText.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        timeStart += Time.deltaTime;
        timerText.transform.localScale = startSize* sizeCurve.Evaluate(timeStart);
	}

    public IEnumerator StartTimer()
    {
        timeStart = 0;
        timerText.text = "3";
        yield return new WaitForSeconds(1);
        timerText.text = "2";
        timeStart = 0;
        yield return new WaitForSeconds(1);
        timerText.text = "1";
        timeStart = 0;
        yield return new WaitForSeconds(1);
        timerText.text = "GO";
        timeStart = 0;
        yield return new WaitForSeconds(1);
        timerText.text = "";
        
    }
}
