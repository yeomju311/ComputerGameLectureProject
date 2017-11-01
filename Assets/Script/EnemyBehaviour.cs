using UnityEngine;
using System.Collections;

public class MonsterState : MonoBehaviour {

	private GameObject player;
	private float distance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (transform.position, player.transform.position);

		if(distance <= 1)
		{
			transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		}
	}
}
