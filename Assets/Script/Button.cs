using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		AutoFade.LoadLevel ("main", 0.5f, 0.5f, Color.black);
	}

	public void Menu() {
		AutoFade.LoadLevel ("menu", 0.5f, 0.5f, Color.black);
	}

	public void Restart() {
		AutoFade.LoadLevel ("main", 0.5f, 0.5f, Color.black);
	}
}
