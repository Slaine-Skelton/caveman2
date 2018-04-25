using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	GameObject player;
	bool attack = false;
	Animator myAnimator;
	bool ishitting = false;

	private AudioSource audioSource;
	private Sounds sounds;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>(); 

		player = GameObject.FindGameObjectWithTag("Player");

		audioSource = player.GetComponent<AudioSource>();
		sounds = player.GetComponent<Sounds>();
	}
	
	// Update is called once per frame
	void Update () {
		if (attack)
		{
			GetPlayer();
		}
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		string tag = collision.transform.tag;
		if (tag == "Player")
		{
			//gameObject.GetComponent<FollowPath>().doMove = false;
			Destroy(gameObject.GetComponent<FollowPath>());
			audioSource.PlayOneShot(sounds.audioClips[1], 0.4f);
			attack = true;

		}
	}

	private void GetPlayer()
	{
		float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

		Vector3 PlayerPostion = player.transform.position;

		float triAngleX = PlayerPostion.x - gameObject.transform.position.x;
		float triAngleY = PlayerPostion.y - gameObject.transform.position.y;

		//float heading = Mathf.Atan2(target.x * -1, target.y);
		float heading = Mathf.Atan2(triAngleY, triAngleX);
		transform.rotation = Quaternion.Euler(0f, 0f, (heading * Mathf.Rad2Deg) - 90);
		//Debug.Log("" + (heading * Mathf.Rad2Deg));

		GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(
				transform.position, PlayerPostion, 3 * Time.deltaTime));

		if(distance < 6.2f && !ishitting)
		{
			audioSource.PlayOneShot(sounds.audioClips[5], 0.7f);
			player.GetComponent<Health>().Subtract(-1);
			ishitting = true;
			//Debug.Log("hitting player");
			myAnimator.SetTrigger("hit");
			StartCoroutine(delayFall());
		}
	}

	IEnumerator delayFall()
	{
		yield return new WaitForSeconds(0.8f);
		ishitting = false;
		myAnimator.ResetTrigger("hit");
	}
}
