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

		if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("introPart2"))
		{
			isPlaying = true;
			Debug.Log("is playing");
		}

		if (isPlaying && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("introPart2"))
		{
			Debug.Log("Load level");
			LoadLevel1();
		}
	}

	public void LoadLevel1()
	{
		SceneManager.LoadScene("level1");
	}
}
