using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerMoveSpeed;
	public float playerJumpForce;
	private Rigidbody rigidbody;
	private bool isJumping = false;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed;

		//transform.Rotate(0, x, 0);
		transform.Translate(x, 0, z);

		if (Input.GetButton("Jump") && !isJumping)
		{
			isJumping = true;
			rigidbody.AddForce(new Vector3(0, playerJumpForce, 0));
		}

		if (isJumping)
		{
			if(0.1f >= transform.position.y && transform.position.y >= -0.1f && rigidbody.velocity.y <= 0)
			{
				isJumping = false;
			}
		}
	}
	
}
