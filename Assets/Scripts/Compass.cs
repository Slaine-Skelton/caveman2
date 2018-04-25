using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	public GameObject Ending;
	Vector3 EndPostion;
	float triAngleX;
	float triAngleY;

	// Use this for initialization
	void Start () {
		EndPostion = Ending.transform.position;
		triAngleX = EndPostion.x - gameObject.transform.position.x;
		triAngleY = EndPostion.y - gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		GetDirection();
	}

	private void GetDirection()
	{
		//float heading = Mathf.Atan2(target.x * -1, target.y);
		float heading = Mathf.Atan2(triAngleY, triAngleX);
		transform.rotation = Quaternion.Euler(0f, 0f, (heading * Mathf.Rad2Deg));
		//Debug.Log("" + (heading * Mathf.Rad2Deg));
	}
}
