using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolMiniGamePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private float rotation;
	
	// Update is called once per frame
	void Update ()
	{
		var maxRot = 38;
		var minRot = -38;
		var x = Input.GetAxis("Horizontal") * -1;
		if (rotation + x >= minRot && rotation + x <= maxRot)
		{
			rotation = rotation + x;
		}
	}

	private void FixedUpdate()
	{
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
	}
}
