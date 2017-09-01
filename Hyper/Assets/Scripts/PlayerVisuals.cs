using UnityEngine;

public class PlayerVisuals : MonoBehaviour {

    public Color32 playerColor;

    public GameObject playerController;

    public GameObject Trail1;
    public GameObject Trail2;

    Vector3 velocity = Vector3.zero;
    public float smoothTime;

    public bool gameOn;

	// Use this for initialization
	void Start () {
        GetComponentInChildren<Renderer>().material.SetColor("_Player_Color", playerColor);
        Trail1.GetComponent<TrailRenderer>().material.SetColor("_Color", playerColor);
        Trail2.GetComponent<TrailRenderer>().material.SetColor("_Color", playerColor);


    }

    void FixedUpdate()
    {
        if (gameOn)
        {
            transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position, ref velocity, smoothTime);
        }
    }
}
