using UnityEngine;
using System.Collections;

public class ReachPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "Player")
			AutoFade.LoadLevel("succeedEnding", 0.5f, 0.5f, Color.black);
	}
}
