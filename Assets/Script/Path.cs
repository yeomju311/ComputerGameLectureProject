using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

	public bool isDebug = true;
	public float Radius = 2.0f;
	public Vector3[] pointA;

	public float Length
	{
		get{
			return pointA.Length;
		}
	}

	public Vector3 GetPoint (int index)
	{
		return pointA[index];
	}

	void OnDrawGizmo()
	{
		if (!isDebug)
			return;
		for (int i=0; i<pointA.Length; i++)
			Debug.DrawLine (pointA [i], pointA [i + 1], Color.red);
	}

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
