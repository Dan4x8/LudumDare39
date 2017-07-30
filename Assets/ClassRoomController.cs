using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomController : MonoBehaviour {

	public bool AvoidObjectsMinigame = false;
	public ThrownSchoolObject ThrownObject;

	// Use this for initialization
	void Start ()
	{
	}

	float timer;

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (AvoidObjectsMinigame)
		{
			if (timer <= 0f)
			{
				timer = Random.Range(2f, 5f);
				var obj = Instantiate(ThrownObject);
				obj.TargetPoint = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
			}
		}
	}
}
