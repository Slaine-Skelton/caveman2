using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour {

	public bool doMove = true;
	public float moveSpeed = 10f;
	public float distanceToNodeTolerance = 20f;

	GameObject Path;
	private CarPath pathToFollow;
	public Vector2 target;
	private Vector2 currentNodePosition;
	Rigidbody2D body;
	public bool useTriggers = true;

	public int currentNode = 0;
	bool blockNode = false;
	private CarSpawner carSpawner;

	GameObject boundry;

	void Start()
	{
		Path = transform.parent.gameObject;

		body = GetComponent<Rigidbody2D>();
		pathToFollow = Path.GetComponent<CarPath>();
		carSpawner = Path.GetComponent<CarSpawner>();

		target = pathToFollow.GetFirstNode();
		//Debug.Log("success");

		boundry = GameObject.FindGameObjectWithTag("outOfBounds");
	}

	void Update()
	{
		if (doMove)
		{

			body.MovePosition(Vector2.MoveTowards(
				transform.position, target, moveSpeed * Time.deltaTime));

			if ((Vector2.Distance(transform.position, currentNodePosition) >= distanceToNodeTolerance) && blockNode)
			{
				blockNode = false;
				//Debug.Log(Vector2.Distance(transform.position, currentNodePosition));
			}


		}

		float triAngleX = target.x - gameObject.transform.position.x;
		float triAngleY = target.y - gameObject.transform.position.y;

		//float heading = Mathf.Atan2(target.x * -1, target.y);
		float heading = Mathf.Atan2(triAngleY, triAngleX);
		transform.rotation = Quaternion.Euler(0f, 0f, (heading * Mathf.Rad2Deg) - 90);
		//Debug.Log("" + (heading * Mathf.Rad2Deg));

		//ignore out of bound perimeter
		
		Physics2D.IgnoreCollision(boundry.GetComponent<EdgeCollider2D>(), GetComponent<CapsuleCollider2D>());

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		string tag = collision.gameObject.tag;

		if (useTriggers)
		{
			if (tag == "carNodes" && !blockNode)
			{
				currentNodePosition = pathToFollow.GetNextNodePosition(currentNode);
				target = pathToFollow.GetNextNodePosition(++currentNode);
				
				blockNode = true;
				//Debug.Log("Block node: TRUE");

			}

			if(tag == "carNodes" && pathToFollow.GetNumNodes() == currentNode)
			{
				carSpawner.SetCurrentNumCars(-1);
				Destroy(gameObject);
			}

		}
	}
}
