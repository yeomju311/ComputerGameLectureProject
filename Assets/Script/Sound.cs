using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	public AudioSource monsterAttackSound;
	public AudioSource alienAttackSound;
	public AudioSource resetSound;
	public AudioSource damageSound;
	public AudioSource destroySound;
	public AudioSource playerDamageSound;

	private Vector3 soundPos;

	// Use this for initialization
	void Start () {
		//monsterAttackSound.Stop();
		//alienAttackSound.Stop();
		//resetSound.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		soundPos = Camera.main.transform.position;

		monsterAttackSound.transform.position = soundPos;
		alienAttackSound.transform.position = soundPos;
		resetSound.transform.position = soundPos;
		damageSound.transform.position = soundPos;
		destroySound.transform.position = soundPos;
		playerDamageSound.transform.position = soundPos;

		if(GameObject.FindGameObjectWithTag("MonsterAttack") == null){
			monsterAttackSound.Stop();
			alienAttackSound.Stop();
		}
	}

	public void PlaySound(Transform t){
		if(t.FindChild("Monster"))
			monsterAttackSound.Play ();
		else if(t.FindChild("Alien"))
			alienAttackSound.Play();
		else if(t.tag == "ResetPoint")
			resetSound.Play();
		else if(t.tag == "Stone")
			damageSound.PlayOneShot(damageSound.clip);
		else if(t.tag == "PlayerCollider")
			playerDamageSound.PlayOneShot(playerDamageSound.clip);
		else
			destroySound.PlayOneShot(destroySound.clip);
	}

	public void StopSound(Transform t) {
		if(t.tag == "ResetPoint")
			Invoke("SoundStopTime", 1.5f);
	}

	public void SoundStopTime() {
		resetSound.Stop();
	}
}
