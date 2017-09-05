using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour {

    public AnimationCurve horizontal;
    public AnimationCurve vertical;
    public AnimationCurve forward;

    public float speed = 1;
    Vector3 origin;

    float localTime;
	// Use this for initialization
	void Start () {
        origin = transform.eulerAngles;
        StartCoroutine(CameraTime());
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.eulerAngles = new Vector3(
            origin.x + horizontal.Evaluate(localTime),
            origin.y + vertical.Evaluate(localTime),
            origin.z + forward.Evaluate(localTime));
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed += 0.1f;
        }
        */
    }

    IEnumerator CameraTime()
    {
        while(true)
        {
            localTime += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
    }
}
