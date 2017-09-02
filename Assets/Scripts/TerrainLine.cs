using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLine : MonoBehaviour {

	LineRenderer lineRenderer;

	// Use this for initialization
	void Start () 
	{
		lineRenderer = GetComponent<LineRenderer>();

		Vector3[] _linePositions = new Vector3 [lineRenderer.transform.childCount];
	
		for(int i = 0; i< lineRenderer.transform.childCount; i++)
		{
			_linePositions [i] = lineRenderer.transform.GetChild(i).transform.position;
		}

		lineRenderer.positionCount = _linePositions.Length;

		lineRenderer.SetPositions(_linePositions);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
