using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {
	
	private SimpleFSM simpleFSM;

	// Use this for initialization
	void Start () {
		simpleFSM = gameObject.transform.parent.GetComponent<SimpleFSM> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(simpleFSM.curState != SimpleFSM.FSMState.Attack){
			if(gameObject.tag == "Monster") {
				animation ["Take 001"].speed = 0.5f;
				animation.Play ("Take 001");
			}
			else if(gameObject.tag == "Alien") {
				animation ["Take 001"].speed = 1.5f;
				animation.Play ("Take 001");
			}
		}
	}

	public void PlayAttack() {

		if(gameObject.tag == "Monster") {
			animation ["Take 001"].speed = 2.0f;
			animation.Play ("Take 001");
		}
		else if(gameObject.tag == "Alien") {
			animation ["Take 001"].speed = 3.0f;
			animation.Play ("Take 001");
		}
	}
}
