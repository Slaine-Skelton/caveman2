using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTimer : MonoBehaviour {

	Animator myAnimator;
	bool isPlaying = false;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Nav.currentScene == 1 && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("introPart2"))
		{
			isPlaying = true;
			Debug.Log("is playing");
		}
		else if (Nav.currentScene == 3 && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("cutScene2"))
		{
			isPlaying = true;
			Debug.Log("is playing");
		}

		if (Nav.currentScene == 1 && isPlaying && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("introPart2"))
		{
			Debug.Log("Load level");
			LoadNextLevel("level1");
		}
		else if (Nav.currentScene == 3 && isPlaying && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("cutScene2"))
		{
			Debug.Log("Load level");
			LoadNextLevel("level2");
		}
	}

	public void LoadNextLevel(string str)
	{
		SceneManager.LoadScene(str);
	}
}
