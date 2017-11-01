using UnityEngine;
using System.Collections;

public class ResetParticle : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Destroy (gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + new Vector3 (0, 1, 0);
	}
}
