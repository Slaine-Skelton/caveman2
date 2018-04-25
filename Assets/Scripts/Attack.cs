using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject blood;
    public GameObject bloodPool;

    private Animator myAnimator;
    public bool ishitting = false;

	private AudioSource audioSource;
	private Sounds sounds;

    //private CapsuleCollider2D clubCollider;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
		//clubCollider = GetComponent<CapsuleCollider2D>();

		audioSource = GetComponent<AudioSource>();
		sounds = GetComponent<Sounds>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown("space") && !ishitting)
		{
			//Debug.Log("hit");
			ishitting = true;
			myAnimator.SetTrigger("hit");
			audioSource.PlayOneShot(sounds.audioClips[6], 0.7f);
			gameObject.transform.localScale = new Vector3(0.09f, 0.09f);
			StartCoroutine(delayFall());
		}


	}
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.transform.tag;

		if ((tag == "civilian" || tag == "man" || tag == "woman" || tag == "cop") && ishitting)
		{
			collision.transform.GetComponent<Health>().Subtract(-1);

			GameObject bloodsplatter = Instantiate(blood);
			bloodsplatter.transform.position = collision.transform.position;

			if (collision.transform.GetComponent<Health>().IsDead())
			{
				if(tag == "cop" || tag == "man")
				{
					audioSource.PlayOneShot(sounds.audioClips[3], 0.7f);
				}
				else if (tag == "woman")
				{
					audioSource.PlayOneShot(sounds.audioClips[2], 0.4f);
				}
				//Debug.Log("dead");
				Destroy(collision.gameObject);
				GameObject bloodDeadPool = Instantiate(bloodPool);
				bloodDeadPool.transform.position = collision.transform.position;
			}

		}
    }

	

	IEnumerator delayFall()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.transform.localScale = new Vector3(0.08f, 0.08f);
        ishitting = false;
        myAnimator.ResetTrigger("hit");
        gameObject.transform.localScale = new Vector3(0.08f, 0.08f);
    }
}
