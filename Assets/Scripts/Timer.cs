using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
	// Start is called before the first frame update
	public float totalTime = 90.0f;
	private GameObject Life1;
	private GameObject Life2;
	private GameObject Life3;

	float timeLeft;
	private Text timerText;
	private float seconds, milliseconds;

	void Start()
	{
		Life1 = GameObject.FindGameObjectWithTag("life1");
		Life2 = GameObject.FindGameObjectWithTag("life2");
		Life3 = GameObject.FindGameObjectWithTag("life3");
		timerText = this.GetComponent<Text> () as Text;
		timeLeft = totalTime;
	}

	// Update is called once per frame
	void Update()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft < 0)
		{
			timeLeft = totalTime;
			if (Life3.active)
			{
				Life3.SetActive(false);
			}
			else if (Life2.active)
			{
				Life2.SetActive(false);
			}
			else if (Life1.active)
			{
				Life1.SetActive(false);
				SceneManager.LoadScene("SceneFinal");
			}

		}

		timerText.text = timeLeft.ToString("00.00");
	}
}
