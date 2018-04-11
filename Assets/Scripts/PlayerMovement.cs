using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    private Vector2 inputAmount = Vector2.zero;
    public Rigidbody2D body;

    public float direction = 0;
    public Vector3 lastCheckpoint;

    private Vector3 mousePosition;

	//animation
	private Animator myAnimator;

    public int meat = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lastCheckpoint = transform.position;

		myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        inputAmount.x = Input.GetAxis("Horizontal");
        inputAmount.y = Input.GetAxis("Vertical");

		if(inputAmount.x != 0 || inputAmount.y != 0)
		{
			myAnimator.SetFloat("isWalking", 1f);
		}
		else
		{
			myAnimator.SetFloat("isWalking", 0);
		}

        direction = inputAmount.x;

        float heading = Mathf.Atan2(inputAmount.x * -1, inputAmount.y);
        transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

        inputAmount *= speed;
        //inputAmount = Vector2.ClampMagnitude(inputAmount, speed);

        body.velocity = inputAmount;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
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
    }
}

