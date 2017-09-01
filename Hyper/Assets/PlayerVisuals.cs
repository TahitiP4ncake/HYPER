using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour {

    public Color32 playerColor;

    public GameObject playerController;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<MeshRenderer>().material.SetColor("Player_Color", playerColor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
