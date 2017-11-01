using UnityEngine;
using System.Collections;

public class SucceedCredit : MonoBehaviour {

	float reachTime;
	float bestT;
	string strTime;
	public GUIText seeTime;
	
	// Use this for initialization
	void Start () {
		this.seeTime.enabled = false;
		
		if (Singleton.Instance.recTime <= Singleton.Instance.bestTime)
			Singleton.Instance.bestTime = Singleton.Instance.recTime;
		
		reachTime = Singleton.Instance.recTime;
		int sec = (int)reachTime%60;
		int min = (int)(reachTime/60)%60;
		
		bestT = Singleton.Instance.bestTime;
		int bSec = (int)bestT&60;
		int bMin = (int)(bestT/60)%60;
		
		Debug.Log ("succeedCredit reachTime : " + reachTime);
		Debug.Log("succeedCredit bestT : " + bestT);
		
		seeTime.text = string.Format ("   {0:D2} : {1:D2}             {2:D2} : {3:D2}", min, sec, bMin, bSec); 
		
		StartCoroutine("SeeText");
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetButtonDown("Fire1"))
			//AutoFade.LoadLevel("main", 0.5f, 0.5f, Color.black);
		
	}
	
	IEnumerator SeeText(){
		//canSee = false;
		yield return new WaitForSeconds(2.0f);
		this.seeTime.enabled = true;
		yield return new WaitForSeconds(4.0f);
		this.seeTime.enabled = false;
	}
}
