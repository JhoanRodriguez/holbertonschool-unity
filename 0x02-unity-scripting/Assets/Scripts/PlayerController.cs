using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float speed = 10f;
	public float forces = 500f;
	private int score = 0;

	public int health = 5;



	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, forces * Time.deltaTime);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -forces * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-forces * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(forces * Time.deltaTime, 0, 0);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score += 1;
			Debug.Log($"Score: {score}");
			Destroy(other.gameObject);
		}

		if (other.CompareTag("Trap"))
		{
			health -= 1;
			Debug.Log($"Health: {health}");
		}
		if (other.CompareTag("Goal"))
		{
			Debug.Log("You win!");
		}

	}
	void Update()
	{
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene("maze");
		}
	}
}
