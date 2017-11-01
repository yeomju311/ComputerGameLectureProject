using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float speed;
	float rotationSpeed = 3.0f;
	Animator anna;
	public GameObject stonePrefab;
	float initialVelocity = 5.0f;
	public Transform make;
	bool isCreated = false;
	private float InstantiationTimer = 0.0f;
	float forceStone = 3.0f;

	void Start () {
			anna = gameObject.GetComponentInChildren<Animator> ();
			speed = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController annaController = gameObject.GetComponent<CharacterController>();
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		InstantiationTimer += Time.deltaTime;
		RaycastHit raycastHit;
		
		if(Physics.Raycast (cameraRay, out raycastHit, 100)){
			Vector3 dir = raycastHit.point - transform.position;
			//dir.y = 1.0f;
			Debug.DrawRay(transform.position, dir, Color.white);
			//Quaternion characterTargetRotation = Quaternion.LookRotation (dir);
			//transform.rotation = Quaternion.RotateTowards (transform.rotation, characterTargetRotation, rotationSpeed);
		}
		
		if ((Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0)) {

			anna.animation.CrossFade("walk");
			
			transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
			Vector3 forward = transform.TransformDirection(Vector3.forward);
			float curSpeed = speed * Input.GetAxis("Vertical");
			annaController.SimpleMove(forward * curSpeed);
		}

		if(Input.GetButtonDown("Fire1")){
			//anna.animation.Play ("attack");			

			if(InstantiationTimer >= 0.5f){
				Vector3 direction = raycastHit.point - transform.position;
				GameObject stone;
				Debug.Log(direction);
				/*if(direction.x >= -0.4f && direction.x <=0.0f)
					direction.x -= 1.5f;
				else if(direction.x >= 0.0f && direction.x <= 0.4f)
					direction.x += 1.5f;
				if(direction.z >= -0.3f && direction.z <= -0.1f)
					direction.z += 2.5f;*/
				anna.animation.Play ("attack");
				stone = Instantiate(stonePrefab, make.position, make.rotation) as GameObject;
				stone.GetComponent<Rigidbody>().velocity = direction * initialVelocity;
				stone.GetComponent<Rigidbody>().AddForce(make.forward * forceStone);
				Destroy (stone, 3f);
				InstantiationTimer = 0.0f;
			}
		}
		else {
			//anna.animation.Stop();
		}

	}
	
	void createStone(){
		//RaycastHit raycastHit;
		
	}

}