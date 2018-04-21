using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPath : MonoBehaviour {

	public Transform[] PathNodes;
	public bool loop = true;
	//private int currentNode = 0;

	public Vector2 GetFirstNode()
	{
		return PathNodes[0].position;
	}
	
	public int GetNumNodes()
	{
		return PathNodes.Length;
	}

	public Vector2 GetNextNodePosition(int targetNode)
	{
		Vector2 position = Vector2.zero;

		if (targetNode < PathNodes.Length)
		{
			position = PathNodes[targetNode].position;
		}
		else if (!loop)
		{
			//do nothing
		}
		else
		{
			targetNode = 0;
			position = PathNodes[targetNode].position;
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
						{
							Gizmos.DrawLine(PathNodes[i].position, PathNodes[i + 1].position);
						}
						else if (!loop)
						{
							//do nothing
						}
						else
						{
							Gizmos.DrawLine(PathNodes[i].position, PathNodes[0].position);
						}
					}
				}
			}
		}
	}
}
