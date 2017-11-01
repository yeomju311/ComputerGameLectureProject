using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {
	public GameObject attackPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other){
		GameObject aPrefab;
		if(other.gameObject.tag=="Enemy"){
			aPrefab = Instantiate(attackPrefab, transform.position, transform.rotation) as GameObject;
			Destroy(aPrefab, 2f);
		}
	}
}
