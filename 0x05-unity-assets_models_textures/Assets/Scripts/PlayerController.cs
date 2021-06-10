using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float horizontalMove;
	private float verticalMove;
	public CharacterController player;

	private Vector3 playerInput;

	public float jumpForce = 3;
	public float gravity = 9.8f;
	public float fallVelocity = 5f;
	public float speed = 5f;
	void Start()
	{
		player = GetComponent<CharacterController>();
	}

	void Update()
	{
		horizontalMove = Input.GetAxis("Horizontal");
		verticalMove = Input.GetAxis("Vertical");

		playerInput = new Vector3(horizontalMove, 0, verticalMove);
		playerInput = Vector3.ClampMagnitude(playerInput, 1);


		SetGravity();
		PlayerSkills();

		player.Move(playerInput * speed * Time.deltaTime);

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

	public void PlayerSkills()
	{
		if (player.isGrounded && Input.GetButtonDown("Jump"))
		{
			fallVelocity = jumpForce;
			playerInput.y = fallVelocity;
		}
	}
}
