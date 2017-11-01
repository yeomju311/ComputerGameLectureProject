using UnityEngine;
using System.Collections;

public class FailCredit : MonoBehaviour {
	
	public GUITexture fail;
	public GameObject p1, p2;
	
	// Use this for initialization
	void Start () {
		this.fail.enabled = false;
		p1.SetActiveRecursively(false);
		p2.SetActiveRecursively(false);

		StartCoroutine("SeeTexture");
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine("SeeTexture");
		//if(Input.GetButtonDown("Fire1"))
			//Application.LoadLevel("main");
	}
	
	IEnumerator SeeTexture(){
		yield return new WaitForSeconds(10.0f);
		this.fail.enabled = true;
		p1.SetActiveRecursively(true);
		p2.SetActiveRecursively(true);
	}
}
