using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPath : MonoBehaviour
{
    public Transform[] PathNodes;
    private int currentNode = 0;

    public Vector2 GetFirstNode()
    {
        return PathNodes[0].position;
    }

    public Vector2 GetNextNodePosition()
    {
        Vector2 position = Vector2.zero;
        currentNode++;

        if (currentNode < PathNodes.Length)
        {
            position = PathNodes[currentNode].position;
        }
        else
        {
            currentNode = 0;
            position = PathNodes[currentNode].position;
        }
        return position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (PathNodes != null)
        {
            if (PathNodes.Length > 0)
            {
                if (PathNodes.Length > 1)
                {
                    for (int i = 0; i < PathNodes.Length; i++)
                    {
                        if (i + 1 < PathNodes.Length)
                            Gizmos.DrawLine(PathNodes[i].position, PathNodes[i + 1].position);
                        else
                            Gizmos.DrawLine(PathNodes[i].position, PathNodes[0].position);
                    }
                }
            }
        }
    }
}
