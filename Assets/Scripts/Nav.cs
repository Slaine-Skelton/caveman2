using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nav : MonoBehaviour {

	static public int currentScene;
	PlayerMovement player;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene().buildIndex;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public void RestartLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(currentScene);
	}

	public void QuitLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public void ContinueLevel()
	{
		player.escapePressed = !player.escapePressed;
		player.ReturnToGame();
	}

}
