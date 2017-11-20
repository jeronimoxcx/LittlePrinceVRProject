using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour {

	public float speed = 0.0001f;
	public Transform spaceshipTransform;
	public GameObject enemyPrefab;

	void Start () {
		
		GameObject temp = Instantiate(enemyPrefab);

		//set position
		temp.transform.position = spaceshipTransform.position;

		//set velocity
		Vector3 initialVelocity = new Vector3 (Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f), -1);
		initialVelocity.Normalize();
		initialVelocity *= speed;
        
		temp.GetComponent<Rigidbody> ().velocity = initialVelocity;
		Debug.Log ("initial velocity: " + temp.GetComponent<Rigidbody> ().velocity);
	}

	void Update () {
	
	}
}

