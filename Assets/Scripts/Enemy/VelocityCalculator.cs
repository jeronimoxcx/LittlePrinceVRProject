using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculator : MonoBehaviour {

	Transform targetTransform;

	public float speed = 0.0001f;
	public float deltaVelocityDir = 0.01f;

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
		Debug.Log (curPosition);

		//get the current velocity
		curDir = gameObject.GetComponent<Rigidbody> ().velocity;
		curDir.Normalize ();
		Debug.Log ("current dir: " + curDir);

		//get the toward velocity
		towardDir = targetTransform.position - curPosition;
		towardDir.Normalize();
		Debug.Log ("toward dir: " + towardDir);

		//interpolate two vectors
		updatedDir = Vector3.Lerp(curDir, towardDir, 1.0f);
		updatedDir.Normalize ();
		Debug.Log ("updated dir: " + updatedDir);
		Debug.Log ("delta position: " + updatedDir*speed*Time.deltaTime);

		//change the position
		gameObject.GetComponent<Rigidbody>().velocity = updatedDir*speed;
		gameObject.transform.position = curPosition + updatedDir * speed * Time.deltaTime;
	}
}
