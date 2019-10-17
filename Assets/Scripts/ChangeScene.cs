using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
	public void changeScene(string nextScene)
	{
		SceneManager.LoadScene(nextScene);
	}

	public void exit()
	{
		Application.Quit();
	}
}
