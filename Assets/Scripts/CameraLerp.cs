using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour {

    public AnimationCurve horizontal;
    public AnimationCurve vertical;
    public AnimationCurve forward;

    public float speed=1;
    Vector3 origin;

	// Use this for initialization
	void Start () {
        origin = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.eulerAngles = new Vector3(
            origin.x + horizontal.Evaluate(Time.time*speed),
            origin.y + vertical.Evaluate(Time.time*speed),
            origin.z + forward.Evaluate(Time.time*speed));
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            speed += 0.1f;
        }
        */
    }
}
