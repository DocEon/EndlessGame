using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scenes
{
    Controls = 0,
    Game = 1
}

public class OpenGame : MonoBehaviour {    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)Scenes.Game);
            //Application.LoadLevel(1);
        }

    }
}
