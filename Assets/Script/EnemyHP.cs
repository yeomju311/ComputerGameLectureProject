using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public Camera worldCam;
	public Camera uiCam;
	public GameObject headUpPosition;
	public GameObject destroyParticle;
	public float enemyHp = 100;
	public UISprite hp;
	public UISprite background;

	private Vector3 targetPosition;
	private Sound sound;

	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("Sound").GetComponent<Sound> ();
	} 
	
	// Update is called once per frame
	void Update () {	
		// 플레이어의 시야에 적이 들어오면 HP를 표시
		if(ViewHP() && enemyHp > 0) {
			hp.enabled = true;
			background.enabled = true;

			Vector3 HPposition = worldCam.WorldToViewportPoint(headUpPosition.transform.position);
			hp.transform.position = uiCam.ViewportToWorldPoint (HPposition);
			HPposition = hp.transform.localPosition;
			HPposition.x = Mathf.RoundToInt (HPposition.x);
			HPposition.y = Mathf.RoundToInt (HPposition.y);
			HPposition.z = 0.0f;
			hp.transform.localPosition = HPposition;
			background.transform.localPosition = HPposition;
		} else {
			hp.enabled = false;
			background.enabled = false;
		}

		if(enemyHp <= 0) {
			GameObject p = (GameObject)Instantiate(destroyParticle, gameObject.transform.position, gameObject.transform.rotation)
				as GameObject;
			Destroy(p, 1.0f);
			Destroy(gameObject, 0.5f);
			sound.PlaySound(p.transform);
		}
	}

	void OnCollisionEnter(Collision col) {
		if(col.transform.tag == "Stone")
		{
			sound.PlaySound(col.transform);
			//col.transform.SendMessage("Hit");
			enemyHp -= 35.0f;
			hp.fillAmount = enemyHp * 0.01f;
			Debug.Log("enemy " + enemyHp);
		}
	}

	bool ViewHP()
	{
		//플레이어의 시야에 적이 들어오는지 확인 
		RaycastHit hit;
		Vector3 rayDirection = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;

		if(Physics.Raycast(GameObject.FindGameObjectWithTag("Player").transform.position, rayDirection, out hit, 20)) {
			if(hit.collider.transform == transform) 
				return true;
		}
		return false; 
	}
}