using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour {

	public Vector3 goalPos = new Vector3 (0 , 0, 0);
	public Vector3 startPos = new Vector3 (0 , -10, 0);
	public float speed = 5; // from start to goal
	public float clicksNeeded = 1; //clicks needed to defeat
	public float respawnTime = 10;

	Vector3 wayVector;
	float distanceMultiplier;


	// Use this for initialization
	void Start () {
		wayVector = goalPos - startPos;
		distanceMultiplier = wayVector.magnitude;
		transform.position = startPos;
		
	}
	
	// Update is called once per frame
	void Update () {
		float offset = (goalPos - transform.position).magnitude;
		float movement = Time.deltaTime / speed * distanceMultiplier;
		
		if (offset >5* movement){

			transform.position = transform.position + wayVector.normalized*movement;
		
		}
	}
}
