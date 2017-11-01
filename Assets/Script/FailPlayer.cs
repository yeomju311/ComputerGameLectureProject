using UnityEngine;
using System.Collections;

public class FailPlayer : MonoBehaviour {

	Animator anna;

	// Use this for initialization
	void Start () {
		anna = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anna.animation.CrossFade("walk");
	}
}
