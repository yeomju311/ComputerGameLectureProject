using UnityEngine;
using System.Collections;

public class ShootParticle : MonoBehaviour {

	private float destroyRate = 2.0f;
	private float deltaTime = 0.0f;

	public int rotateX;

	// Use this for initialization
	void Start () {
		transform.Rotate (rotateX, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;

		if(deltaTime >= destroyRate)
			Destroy(gameObject);

		if(transform.parent.FindChild("Alien")){
			transform.rigidbody.AddForce (transform.forward * 10);
			transform.rigidbody.velocity = transform.forward * 10.0f;
		}
	}

	void Hit() {
		if(transform.parent.FindChild("Monster")){
			Destroy(gameObject, 0.5f);
		} else Destroy(gameObject);
	}
}
