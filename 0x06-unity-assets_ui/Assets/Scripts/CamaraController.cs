using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{

	public float sensitivity = 1f;
	private Transform parent;

	// Start is called before the first frame update
	void Start()
	{
		parent = transform.parent;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		Rotate();
	}
	void Rotate()
	{
		float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		parent.Rotate(Vector3.up, mouseX);
	}
}
