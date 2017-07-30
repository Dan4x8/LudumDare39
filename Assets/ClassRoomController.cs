using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassRoomController : Controller
{

	public bool AvoidObjectsMinigame = false;
	public ThrownSchoolObject[] ThrownObjects;

	public BlobTarget BlobTargetPrefab;
	public GameObject Blob;

	public string[] SchoolBlobs;

	// Use this for initialization
	void Start()
	{
		PauseTimer = true;
		ShowDialog(9);
		StartCoroutine(WaitForMarket());
	}

	float timer;
	float blobTimer;

	// Update is called once per frame
	void Update()
	{
		if (IsPaused)
		{
			return;
		}
		timer -= Time.deltaTime;
		blobTimer -= Time.deltaTime;

		if (AvoidObjectsMinigame)
		{
			if (timer <= 0f)
			{
				timer = Random.Range(1f, 4f);
				var obj = Instantiate(ThrownObjects[Random.Range(0, ThrownObjects.Length)]);
				obj.Controller = this;
				obj.TargetPoint = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;}
		}

		if (blobTimer <= 0f)
		{
			blobTimer = Random.Range(3f, 7f);
			var target = Instantiate(BlobTargetPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f)), Quaternion.Euler(0f, 0f, 0f));
			var blob = Instantiate(Blob, new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f), 1), Quaternion.Euler(0f, 0f, 0f));
			var blobScript = blob.GetComponentInChildren<BlobScript>();
			blobScript.Target = target;
			blobScript.Text.text = SchoolBlobs[Random.Range(0, SchoolBlobs.Length)];
			blobScript.SetBlobInitHealth(-1);
			blobScript.Difficulty = BlobScript.BlobDifficulty.MoveBackwards;
			blobScript.Behaviour = BlobScript.BlobBehaviour.MoveToTarget;
			blobScript.BlobSpeed = Random.Range(10f, 20f);
		}
	}

	public Dialogbox DialogBox;

	public void ShowDialog(int key, Dictionary<string,string> dict = null)
	{
		Dialogbox db = Instantiate(DialogBox, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
		db.Controller = this;
		db.ShowDialog(key,dict);
	}

	public override void Execute(string action, int[] param)
	{
		ShowDialog(param[0]);
	}

	IEnumerator WaitForMarket()
	{
		float t = 0.0f;
		while (t <= 60f)
		{
			if (!IsPaused)
			{
				t += Time.deltaTime;
			}
			yield return new WaitForEndOfFrame();
			print(t);
		}
		Dictionary<string, string> dict = new Dictionary<string, string>();
		dict.Add("hits", Hits.ToString());
		ShowDialog(10, dict);
		while (IsPaused)
			yield return new WaitForEndOfFrame();
		SceneManager.LoadScene("Market");
	}

	public int Hits = 0;
}