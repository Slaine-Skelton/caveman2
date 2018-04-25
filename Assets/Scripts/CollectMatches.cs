using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMatches : MonoBehaviour {

    public int matchCount = 0;

	private AudioSource audioSource;
	private Sounds sounds;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		sounds = GetComponent<Sounds>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        if(tag == "match")
        {
            matchCount++;
			audioSource.PlayOneShot(sounds.audioClips[0], 0.7f);
			Destroy(collision.gameObject);
        }
    }
	
}
