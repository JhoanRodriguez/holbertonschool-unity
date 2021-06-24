using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public GameObject player;

	public Text TimerText;
	private void OnTriggerEnter(Collider other)
	{
		player.GetComponent<Timer>().enabled = false;
		TimerText.fontSize = 60;
		TimerText.color = Color.green;
	}
}
