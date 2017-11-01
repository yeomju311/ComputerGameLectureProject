using UnityEngine;
using System.Collections;

public class TimeRecord : MonoBehaviour {
	
	float saveTime = 0f;
	public GUIText seeTime;
	
	// Use this for initialization
	void Start () {
		Singleton.Instance.recTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Singleton.Instance.recTime += Time.deltaTime;
		saveTime = Singleton.Instance.recTime;
		int sec = (int)saveTime%60;
		int min = (int)(saveTime/60)%60;
		
		seeTime.text = string.Format ("{0:D2} : {1:D2}", min, sec); 
		
	}
}