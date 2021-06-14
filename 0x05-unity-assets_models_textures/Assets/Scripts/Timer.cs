using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Text TimerText;
	private float timer, minutes, seconds, milliseconds;


	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		minutes = (timer / 60);
		seconds = (timer % 60);
		milliseconds = (timer * 100 % 100);

		TimerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
	}
}
