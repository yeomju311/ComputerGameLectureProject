using UnityEngine;
using System.Collections;

public class Flowers : MonoBehaviour {

	public GameObject flower;
	private GameObject player;
	private float time = 0.5f;
	private float move = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		Vector3 moveForward = transform.forward * move;

		if(time > 0.1f && move < 6) {
			Instantiate(flower, player.transform.position + moveForward, Quaternion.identity);
			Instantiate(flower, player.transform.position + new Vector3(0, 0, -1) + moveForward, Quaternion.identity);
			time = 0;
			move += 0.3f;
		}
	}
}
