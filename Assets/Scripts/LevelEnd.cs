using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	int thisLevel;

	private void Start()
	{
		thisLevel = Nav.currentScene;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		string tag = collision.tag;

		if(collision.tag == "Player")
		{
			Nav.currentScene++;
			thisLevel++;
			SceneManager.LoadScene(thisLevel);
		}
	}
}
