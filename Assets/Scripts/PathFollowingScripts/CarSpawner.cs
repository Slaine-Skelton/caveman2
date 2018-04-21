using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public GameObject carObject;
	public GameObject startNode;
	public int maxNumberOfCars = 1;
	private int currentNumCars = 1;

	public float SpawnRangeStart = 2f;
	public float SpawnRangeEnd = 8f;
	float elapsedTime;
	float spawnTime;

	// Use this for initialization
	void Start () {
		spawnTime = Random.Range(2f, 8f);
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		//Debug.Log(elapsedTime);

		if (elapsedTime > spawnTime && currentNumCars <= maxNumberOfCars)
		{
			GameObject spawned = Instantiate(carObject);
			spawned.transform.parent = transform;
			spawned.transform.position = startNode.transform.position;


			Vector2 redRange, greenRange, blueRange, alphaRange;

			redRange = new Vector2(0.1f, 1f);
			greenRange = new Vector2(0.5f, 1f);
			blueRange = new Vector2(0.5f, 1f);
			alphaRange = new Vector2(1f, 1f);

			//the new color 
			Color color = new Color(0, 0, 0, 0);

			//randomize
			color.r = Random.Range(redRange.x, redRange.y);
            color.g = Random.Range(greenRange.x, greenRange.y);
            color.b = Random.Range(blueRange.x, blueRange.y);
            color.a = Random.Range(alphaRange.x, alphaRange.y);
            

			spawned.GetComponent<SpriteRenderer>().color = color;
			elapsedTime = 0;
			spawnTime = Random.Range(2f, 8f);
			currentNumCars++;
		}

		
	}

	public void SetCurrentNumCars(int num)
	{
		currentNumCars += num;
	}
}
