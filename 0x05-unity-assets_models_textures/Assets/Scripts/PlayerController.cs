using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController player;
	public float jumpForce = 3;
	public float gravity = 9.8f;
	public float fallVelocity = 5f;
	public float speed = 5f;
	private float horizontalMove;
	private float verticalMove;
	private Vector3 playerInput;
	private Transform falling;
	void Start()
	{
		player = GetComponent<CharacterController>();
		falling = GetComponent<Transform>();
	}

	void Update()
	{
		horizontalMove = Input.GetAxis("Horizontal");
		verticalMove = Input.GetAxis("Vertical");

		playerInput = new Vector3(horizontalMove, 0, verticalMove);
		playerInput = Vector3.ClampMagnitude(playerInput, 1);
		playerInput = transform.TransformDirection(playerInput);


		SetGravity();
		PlayerSkills();


		player.Move(playerInput * speed * Time.deltaTime);

		IsFalling();

	}

	void SetGravity()
	{
		if (player.isGrounded)
		{
			fallVelocity = -gravity * Time.deltaTime;
			playerInput.y = fallVelocity;
		}
		else
		{
			fallVelocity -= gravity * Time.deltaTime;
			playerInput.y = fallVelocity;
		}

	}

	void PlayerSkills()
	{
		if (player.isGrounded && Input.GetButtonDown("Jump"))
		{
			fallVelocity = jumpForce;
			playerInput.y = fallVelocity;
		}
	}
	void IsFalling()
	{
		if (falling.position.y < -25f)
			falling.position = new Vector3(0, 40, 0);
	}
}
