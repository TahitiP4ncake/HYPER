using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.Curvy;

public class PlayerMove : MonoBehaviour {

	public SplineController controller;
	public CurvySpline spline01;
	public CurvySpline spline02;

	private CurvySpline newSpline;

	public bool first = true;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			if(first)
			{
				newSpline = spline02;
				
			}
			else
			{
				newSpline = spline01;
			}

			controller.SwitchTo(newSpline, controller.RelativePosition, 0.1f);

			first = !first;

		}
	}

}
