using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	private Sound sound;
	private GameObject player;
	private Vector3 playerPos;
	private Vector3 startPoint;

	public int[] resetPointA = new int[3];
	public GameObject resetParticle;

	private int[] childIndex = new int[10];
	private int index = 0;

	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("Sound").GetComponent<Sound> ();
		startPoint = GameObject.FindGameObjectWithTag ("StartPoint").transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");

		SetPoint ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SetPoint() {
		
		for(int i=0; i<10; i++){
			childIndex[i] = i;
		}

		for(int i=0; i<3; i++){
			index = Random.Range(0, 10);	Debug.Log (index + " first");
			if (childIndex[index] == -1)
			{
				while(childIndex[index] < 0)
					index = Random.Range(0, 10);	Debug.Log(index + " if");
			}
			childIndex[index] = -1;
			resetPointA[i] = index;
		}
	}

	/* void OnTriggerEnter(Collider col) {
		if(col.transform.tag == "PlayerCollider" && (col.transform.localPosition == resetPointA[0]
		   || col.transform.localPosition == resetPointA[1] || col.transform.localPosition == resetPointA[2])){
			Instantiate(resetParticle, player.transform.position + new Vector3(0, 1, 0), player.transform.rotation);
			Invoke("ResetPos", 2);
		}
	} */

	void ResetPointCheck(int index){
		if(resetPointA[0] == index || resetPointA[1] == index || resetPointA[2] == index) {
			Instantiate(resetParticle, player.transform.position + new Vector3(0, 1, 0), player.transform.rotation);
			sound.PlaySound(gameObject.transform);
			Invoke("ResetPos", 2);
		}
	}

	void ResetPos() {
		player.transform.position = startPoint;
		SetPoint ();
		sound.StopSound(gameObject.transform);
	}
}
