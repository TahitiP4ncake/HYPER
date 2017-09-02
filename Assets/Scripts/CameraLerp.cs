using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour {

    public AnimationCurve horizontal;
    public AnimationCurve vertical;
    public AnimationCurve forward;

    Vector3 origin;

	// Use this for initialization
	void Start () {
        origin = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.eulerAngles = new Vector3(
            origin.x + horizontal.Evaluate(Time.time),
            origin.y + vertical.Evaluate(Time.time),
            origin.z + forward.Evaluate(Time.time));

    }
}
