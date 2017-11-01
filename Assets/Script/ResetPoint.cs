using UnityEngine;
using System.Collections;

public class ResetPoint : MonoBehaviour {

	private int index;

	// Use this for initialization
	void Start () {
		Transform t = gameObject.transform;
		for(int i=0; i<10; i++) {
			if(t == transform.parent.GetChild(i))
				index = i;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.transform.tag == "PlayerCollider")
			transform.parent.SendMessage("ResetPointCheck", index);
	}
}
