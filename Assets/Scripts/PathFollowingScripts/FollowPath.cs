using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public bool doMove = true;
    public float moveSpeed = 5f;
    public float distanceToNodeTolerance = 0.2f;

    public GameObject Path;
    private CustomPath pathToFollow;
    public Vector2 target;
    Rigidbody2D body;
    public bool useTriggers = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        pathToFollow = Path.GetComponent<CustomPath>();

        target = pathToFollow.GetFirstNode();
    }

    void Update()
    {
        if (doMove)
        {
            body.MovePosition(Vector2.MoveTowards(
                transform.position, target, moveSpeed * Time.deltaTime));

            if (!useTriggers)
            {
                if (Vector2.Distance(transform.position, target) <= distanceToNodeTolerance)
                {
                    target = pathToFollow.GetNextNodePosition();
                }
            }
        }

        float heading = Mathf.Atan2(target.x * -1, target.y);
        transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (useTriggers)
        {
            if (tag == "PathNode")
            {
                target = pathToFollow.GetNextNodePosition();
            }
        }
    }
}
