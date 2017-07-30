using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobTarget : MonoBehaviour
{
	public Color Color = Color.yellow;
	public float Radius = .5f;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color;
		Gizmos.DrawWireSphere(transform.position, Radius);
	}
}
