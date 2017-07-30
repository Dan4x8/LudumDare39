using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomController : MonoBehaviour {

	public bool AvoidObjectsMinigame = false;
	public ThrownSchoolObject ThrownObject;

	public BlobTarget BlobTargetPrefab;
	public GameObject Blob;

	public string[] SchoolBlobs;

	// Use this for initialization
	void Start ()
	{
	}

	float timer;
	float blobTimer;

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		blobTimer -= Time.deltaTime;

		if (AvoidObjectsMinigame)
		{
			if (timer <= 0f)
			{
				timer = Random.Range(2f, 5f);
				var obj = Instantiate(ThrownObject);
				obj.TargetPoint = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
			}
		}

		if(blobTimer <= 0f)
		{
			blobTimer = Random.Range(3f, 7f);
			var target = Instantiate(BlobTargetPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f)), Quaternion.Euler(0f, 0f, 0f));
			var blob = Instantiate(Blob, new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f),1), Quaternion.Euler(0f, 0f, 0f));
			var blobScript = blob.GetComponentInChildren<BlobScript>();
			blobScript.Target = target;
			blobScript.Text.text = SchoolBlobs[Random.Range(0, SchoolBlobs.Length)];
			blobScript.SetBlobInitHealth(-1);
			blobScript.Difficulty = BlobScript.BlobDifficulty.MoveBackwards;
			blobScript.Behaviour = BlobScript.BlobBehaviour.MoveToTarget;
			blobScript.BlobSpeed = Random.Range(10f,20f);
		}
	}
}
