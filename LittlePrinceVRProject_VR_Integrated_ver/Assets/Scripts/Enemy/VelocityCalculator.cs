using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour {

	Transform targetTransform;

	public float speed = 3.0f;
    public float lerpValue = 0.04f;

	Vector3 curPosition;
	Vector3 curDir;
	Vector3 towardDir;
	Vector3 updatedDir;

	void Start () {
		targetTransform = GameObject.Find ("Single_Rose").transform;
	}

	void Update () {
        
        //get the current position
        curPosition = gameObject.transform.position;

		//get the current velocity
		curDir = gameObject.GetComponent<Rigidbody> ().velocity;

		//get the toward velocity
		towardDir = targetTransform.position - curPosition;
		towardDir.Normalize();

		//interpolate two vectors
		updatedDir = Vector3.Lerp(curDir, towardDir, lerpValue);
		updatedDir.Normalize ();

		//change the position
		gameObject.GetComponent<Rigidbody>().velocity = updatedDir*speed;
        
	}
}
