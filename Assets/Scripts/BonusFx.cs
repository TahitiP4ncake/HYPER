using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFx : MonoBehaviour {

    float anim;

    public Material mat;

	void Start () {
        anim = 0;
	}

	void Update () {
        anim += Time.deltaTime*2;
        mat.SetFloat("_lerp", anim);

        if (anim >= 1)
            Destroy(gameObject);
	}
}
