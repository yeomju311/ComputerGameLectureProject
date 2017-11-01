using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private GameObject player;
	
	private Vector3 camForward;
	private Vector3 camPos;

	private bool right = false;
	private bool left = false;
	private bool upDown = false;

	// Use this for initialization
	void Start () {
		transform.Rotate (9, 0, 0);
		player = GameObject.FindGameObjectWithTag ("Player");
		camPos = new Vector3 (0, 2, -3);
		camForward = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + camPos;

		if (Input.GetKey(KeyCode.RightArrow) && right == false) {
			transform.RotateAround(player.transform.position, Vector3.up, 90);
			camPos = new Vector3 (-3, 2, 0);
			camForward = Vector3.right;
			right = true;
			left = false;
			upDown = false;
		}
		if (Input.GetKey(KeyCode.LeftArrow) && left == false) {
			transform.RotateAround(player.transform.position, Vector3.up, 180);
			camPos = new Vector3 (3, 2, 0);
			camForward = Vector3.left;
			left = true;
			right = false;
			upDown = false;
		}
		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && upDown == false) {
			transform.RotateAround(player.transform.position, Vector3.up, 180);
			camPos = new Vector3(0, 2, -3);
			camForward = Vector3.forward;
			upDown = true;
			left = false;
			right = false;
		}

		transform.forward = camForward;
	}
}
