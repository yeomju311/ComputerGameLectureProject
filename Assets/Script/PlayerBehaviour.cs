using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public Sound sound;
	public GameObject playerAttackParticle;
	public float playerHp = 100;
	public UISprite hp;

	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("Sound").GetComponent<Sound> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHp <= 0) {
			Player playerScript = gameObject.transform.parent.GetComponent<Player>();
			playerScript.enabled = false;
			AutoFade.LoadLevel("failEnding", 0.5f, 0.5f, Color.black);
		}
	}

	//이동할때만?
	/* void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.transform.tag == "MonsterAttack")
		{
			hit.transform.SendMessage("Hit");
			health -= 1;
			Debug.Log(health);
		}
	} */

	void OnCollisionEnter(Collision col) {
		if(col.transform.tag == "MonsterAttack")
		{
			Invoke("AttackParticle", 0.5f);
			col.transform.SendMessage("Hit");
			sound.PlaySound(gameObject.transform);
			playerHp -= 10.0f;
			hp.fillAmount = playerHp * 0.01f;
		}
		/* else if(col.transform.tag == "Enemy")
		{
			AttackParticle();
			playerHp -= 5.0f;
			hp.fillAmount = playerHp * 0.01f;
		} */
		Debug.Log("PlayerHP : " + playerHp); 
	}

	void AttackParticle() {
		GameObject p = (GameObject)Instantiate(playerAttackParticle, transform.position, transform.rotation);
		Destroy(p, 1.0f);
	}
}
