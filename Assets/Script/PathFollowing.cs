using UnityEngine;
using System.Collections;

public class PathFollowing: MonoBehaviour {

	public Path path;
	public float speed = 2.0f;
	public float mass = 5.0f;
	public bool isLooping = true;

	private float deltaDistance;
	private int curPathIndex;
	private float pathLength;
	private Vector3 targetPoint;

	Vector3 currentDeltaDisplacement;

	// Use this for initialization
	void Start () {
		pathLength = path.Length;
		curPathIndex = 0;

		currentDeltaDisplacement = transform.forward;
	}

	// Update is called once per frame
	void Update () {
		deltaDistance = speed * Time.deltaTime;
		targetPoint = path.GetPoint (curPathIndex);

		if (Vector3.Distance (transform.position, targetPoint) < path.Radius) {
			if(curPathIndex < pathLength-1)
				curPathIndex++;
			else if(isLooping)
				curPathIndex = 0;
			else
				return;
		}

		if (curPathIndex >= pathLength - 1 && !isLooping)
			currentDeltaDisplacement += Steer (targetPoint, true) * (Time.deltaTime * Time.deltaTime);
		else
			currentDeltaDisplacement += Steer (targetPoint) * (Time.deltaTime * Time.deltaTime);

		transform.rotation = Quaternion.LookRotation (currentDeltaDisplacement);
		transform.position += currentDeltaDisplacement;
	}

	public Vector3 Steer(Vector3 target, bool bFinalPoint = false)
	{
		Vector3 desiredPosDirection = (target - transform.position);
		float dist = desiredPosDirection.magnitude;
		Vector3 desiredDisplacement;

		desiredPosDirection.Normalize ();

		if (bFinalPoint && dist < 10.0f)
			desiredDisplacement = (deltaDistance * (dist / 10.0f)) * desiredPosDirection;
		else
			desiredDisplacement = deltaDistance * desiredPosDirection;

		float k = 1.0f / (Time.deltaTime * Time.deltaTime);
		Vector3 steeringForce = k * (desiredDisplacement - currentDeltaDisplacement);
		Vector3 acceleration = steeringForce / mass;

		return acceleration;
	}
}
