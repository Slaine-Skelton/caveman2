using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
        {
            myAnimator.SetTrigger("hit");
            gameObject.transform.localScale = new Vector3(0.09f, 0.09f);
            StartCoroutine(delayFall());
        }

        if (Input.GetKeyUp("space"))
        {
            myAnimator.ResetTrigger("hit");
            gameObject.transform.localScale = new Vector3(0.08f, 0.08f);
        }
    }

    IEnumerator delayFall()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.transform.localScale = new Vector3(0.08f, 0.08f);
    }
}
