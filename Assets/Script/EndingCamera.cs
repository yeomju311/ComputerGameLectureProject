using UnityEngine;
using System.Collections;

public class EndingCamera : MonoBehaviour {

    public Transform[] movePoints;
    public float moveSpeed;
	public Transform plane;
	float rotationSpeed = 1.0f;

    private int currentPoint;

    void Start()
    {
        transform.position = movePoints[0].position;
        currentPoint = 0;
    }

    void Update()
    {
	    if (transform.position == movePoints[currentPoint].position)
	           currentPoint++;
	    if (currentPoint >= movePoints.Length){
	           currentPoint--;
		}
	
      	transform.position = Vector3.MoveTowards(transform.position, movePoints[currentPoint].position, moveSpeed * Time.deltaTime);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, movePoints[currentPoint].rotation, rotationSpeed);
    }
}
