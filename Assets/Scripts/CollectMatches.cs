using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMatches : MonoBehaviour {

    public int matchCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.tag;

        if(tag == "match")
        {
            matchCount++;
            Destroy(collision.gameObject);
        }
    }
}
