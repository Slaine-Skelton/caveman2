using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{

    private Rigidbody2D body;
    public float bounceAmount = 3;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "portal")
        {
            //GetComponent<EnemyController>().didBounce = true;
            body.AddForce(-body.velocity * bounceAmount, ForceMode2D.Impulse);
            

            //Invoke("ReEnableMovement", 1);
        }
    }

    private void ReEnableMovement()
    {
        //GetComponent<EnemyController>().didBounce = false;
    }
}
