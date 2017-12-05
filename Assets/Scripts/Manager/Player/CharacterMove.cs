using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    public int jumpcount = 0;
    public Transform cameraTransform;

    float yVelocity = 0.0f;
    public float gravity = -9.8f;

    CharacterController characterController = null;



	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = 
            cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpcount<2)
            {
                yVelocity = jumpSpeed;
                jumpcount += 1;
            }
        }

        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
        
        if (characterController.collisionFlags 
            == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
            jumpcount = 0;
        }

	}
}
