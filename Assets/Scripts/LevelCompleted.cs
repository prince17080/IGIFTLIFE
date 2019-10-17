using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Organs = new List<GameObject>();
    public string NextScene;
    // Update is called once per frame
    void Update()
    {
    	bool levelCompleted = true;
        for (int i = 0; i < Organs.Count; i++)
        {
        	levelCompleted = levelCompleted & (!Organs[i].active);
        }

       	Debug.Log(levelCompleted);

        if (levelCompleted)
        {
			SceneManager.LoadScene(NextScene);
        }
    }
}
