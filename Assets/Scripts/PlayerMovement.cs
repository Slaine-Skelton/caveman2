using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    private Vector2 inputAmount = Vector2.zero;
    private Rigidbody2D body;

    public float direction = 0;
    public Vector3 lastCheckpoint;

    private Vector3 mousePosition;
	public GameObject dead;

	//animation
	private Animator myAnimator;

	bool damageProtection = false;
	Health health;
	public GameObject UiPanel1;
	public GameObject UiPanel2;

	public bool escapePressed = false;

	private AudioSource audioSource;
	private Sounds sounds;

	void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lastCheckpoint = transform.position;
		health = GetComponent<Health>();
		myAnimator = GetComponent<Animator>();

		UiPanel1.SetActive(true);
		UiPanel2.SetActive(false);

		audioSource = GetComponent<AudioSource>();
		sounds = GetComponent<Sounds>();
	}

    void Update()
    {

        inputAmount.x = Input.GetAxis("Horizontal");
        inputAmount.y = Input.GetAxis("Vertical");

		if (inputAmount.x != 0 || inputAmount.y != 0)
		{
			myAnimator.SetFloat("isWalking", 1f);
			direction = inputAmount.x;

			float heading = Mathf.Atan2(inputAmount.x * -1, inputAmount.y);
			transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

			inputAmount *= speed;
			//inputAmount = Vector2.ClampMagnitude(inputAmount, speed);

			body.velocity = inputAmount;

		}
		else
		{
			myAnimator.SetFloat("isWalking", 0);
			body.freezeRotation = true;
			body.velocity = new Vector3(0f,0f,0f);
		}

		
		if (GetComponent<Health>().IsDead())
		{
			//destroy and instatiate
			GameObject deadImage = Instantiate(dead);
			audioSource.PlayOneShot(sounds.audioClips[3], 0.7f);
			deadImage.transform.position = gameObject.transform.position;
			GetComponent<HUD>().healthtext.text = "0";
			Destroy(gameObject);
			GameOverScreen();
		}

		if (Input.GetKeyDown("escape") && !escapePressed)
		{
			Time.timeScale = 0;
			PausedScreen();
		}
		
		if (Input.GetKeyDown("escape") && escapePressed)
		{
			ReturnToGame();
		}

		if (Input.GetKeyUp("escape"))
		{
			escapePressed = !escapePressed;
		}
		
	}

	
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;


		if (tag == "followCar" && !damageProtection)
		{
			health.Subtract(-3);
			audioSource.PlayOneShot(sounds.audioClips[4], 0.7f);
			damageProtection = true;
			StartCoroutine(delayDamage());
		}
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        string tag = collider.gameObject.tag;

        if(tag == "Checkpoint")
        {
            lastCheckpoint = collider.gameObject.transform.position;
        }
        else if(tag == "Kill")
        {
            transform.position = lastCheckpoint;
        }

		if (tag == "health")
		{
			if(health.currentHealth < 10)
			{
				health.Add(1);
			}
			audioSource.PlayOneShot(sounds.audioClips[0], 0.7f);
			Destroy(collider.gameObject);

			lastCheckpoint = gameObject.transform.position;
		}

    }

	IEnumerator delayDamage()
	{
		yield return new WaitForSeconds(0.5f);
		damageProtection = false;
	}

	private void PausedScreen()
	{
		UiPanel1.SetActive(false);
		UiPanel2.SetActive(true);
		UiPanel2.transform.GetChild(0).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(1).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(2).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(3).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(5).gameObject.SetActive(true);
		UiPanel2.transform.GetChild(6).gameObject.SetActive(true);
		UiPanel2.transform.GetChild(7).gameObject.SetActive(true);
	}

	private void GameOverScreen()
	{
		UiPanel1.SetActive(false);
		UiPanel2.SetActive(true);
		UiPanel2.transform.GetChild(0).gameObject.SetActive(true);
		UiPanel2.transform.GetChild(1).gameObject.SetActive(true);
		UiPanel2.transform.GetChild(2).gameObject.SetActive(true);
		UiPanel2.transform.GetChild(3).gameObject.SetActive(true);
		UiPanel2.transform.GetChild(5).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(6).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(7).gameObject.SetActive(false);
		UiPanel2.transform.GetChild(8).gameObject.SetActive(false);
	}

	public void ReturnToGame()
	{
		UiPanel1.SetActive(true);
		UiPanel2.SetActive(false);
		Time.timeScale = 1;
	}

}

