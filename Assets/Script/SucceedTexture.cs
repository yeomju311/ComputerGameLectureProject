using UnityEngine;
using System.Collections;

public class SucceedTexture : MonoBehaviour {
	
	public GUITexture seeTexture;
	public GameObject p1, p2;
	
	// Use this for initialization
	void Start () {
		this.seeTexture.enabled = false;
		p1.SetActiveRecursively(false);
		p2.SetActiveRecursively(false);
		StartCoroutine("SeeTexture");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator SeeTexture(){
		//canSee = false;
		yield return new WaitForSeconds(2.0f);
		this.seeTexture.enabled = true;
		yield return new WaitForSeconds(4.0f);
		this.seeTexture.enabled = false;
		p1.SetActiveRecursively(true);
		p2.SetActiveRecursively(true);
	}
}