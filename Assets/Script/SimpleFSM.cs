using UnityEngine;
using System.Collections;

public class SimpleFSM : FSM {

	public enum FSMState
	{
		Patrol,
		Chase,
		Attack,
		Dead,
	}

	public FSMState curState;
	public GameObject attackParticle;

	private EnemyAnimation EnemyAni;
	private PathFollowing PathScript;
	private Sound sound;
	private GameObject player;
	private bool bDead;
	private int health;
	private float play;

	// Use this for initialization
	protected override void Initialize () {
		EnemyAni = gameObject.GetComponentInChildren<EnemyAnimation> ();
		PathScript = gameObject.GetComponent<PathFollowing> ();
		sound = GameObject.Find ("Sound").GetComponent<Sound> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		curState = FSMState.Patrol;
		bDead = false;
		health = 1;
		play = 0.0f;
		shootRate = 2.0f;
	}
	
	// Update is called once per frame
	protected override void FSMUpdate () {
		switch (curState)
		{
			case FSMState.Patrol: UpdatePatrolState(); break;
			case FSMState.Chase: UpdateChaseState(); break;
			case FSMState.Attack: UpdateAttackState(); break;
			case FSMState.Dead: UpdateDeadState(); break;
		}

		elapsedTime += Time.deltaTime;
		play += Time.deltaTime;

		if(health <= 0)
			curState = FSMState.Dead;
	}

	protected void UpdatePatrolState()
	{
		float dist = Vector3.Distance (transform.position, player.transform.position);
		PathScript.enabled = true;

		if(dist <= 8 && ViewCheck() == true)
		{
			curState = FSMState.Chase;
			PathScript.enabled = false;
		}
	}

	protected void UpdateChaseState()
	{
		float dist = Vector3.Distance (transform.position, player.transform.position);

		if(dist < 8 && ViewCheck() == true)
			curState = FSMState.Attack;
		else if(dist > 10 || ViewCheck() == false)
			curState = FSMState.Patrol;

		Quaternion rot = Quaternion.LookRotation (player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, 2 * Time.deltaTime);
		transform.Translate (Vector3.forward * Time.deltaTime * 1.5f);
	}

	protected void UpdateAttackState()
	{
		float dist = Vector3.Distance (transform.position, player.transform.position);

		if(dist >= 8 && dist <= 10 && ViewCheck() == true)
			curState = FSMState.Chase;
		else if(dist > 10 || ViewCheck() == false)
			curState = FSMState.Patrol;

		Quaternion rot = Quaternion.LookRotation (player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, 2 * Time.deltaTime);

		Shoot ();
	}

	protected void UpdateDeadState()
	{
		if(!bDead)
		{
			bDead = true;
			//Explode();
		}
	}

	private void Shoot()
	{
		Transform shootPoint = gameObject.transform.FindChild ("ShootPoint");

		if(elapsedTime >= shootRate)
		{
			(Instantiate (attackParticle, shootPoint.position, transform.rotation) as GameObject)
				.transform.parent = gameObject.transform;
			EnemyAni.PlayAttack();
			sound.PlaySound(gameObject.transform);
			elapsedTime = 0.0f;
		}
	}

	private bool ViewCheck()
	{
		RaycastHit hit;
		Vector3 rayDirection = player.transform.position - transform.position;

		if((Vector3.Angle(rayDirection, transform.forward) < 90))
		{
		   if(Physics.Raycast(transform.position, rayDirection, out hit, 100))
			{
				if(hit.collider.gameObject.tag == "Player")
					return true;
			} else return false;
		}
		return false;
	}
}
