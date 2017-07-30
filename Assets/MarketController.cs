using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketController : Controller {

	enum State {WaitForClicks,WaitForMilk,MilkDown }

	public GameObject Milk;

	public BlobTarget BlobTargetPrefab;
	public GameObject Blob;

	public string[] MarketBlobs;

	State state = State.WaitForClicks;
	// Use this for initialization
	void Start() {
		PauseTimer = true;
		stuff = new Dictionary<int, bool>();
		for(int i = 12; i<=20;i++)
		{
			stuff.Add(i, false);
		}
		ShowDialog(11);
		runBlobs = true;
	}

	float blobTimer;
	bool runBlobs;
	void Update() {
		if(state == State.WaitForClicks && !IsPaused && !stuff.ContainsValue(false))
		{
			ShowDialog(21);
			StartCoroutine(WaitForFallingMilk());
			state = State.WaitForMilk;
		}

		blobTimer -= Time.deltaTime;
		if (runBlobs && state != State.MilkDown && blobTimer <= 0f)
		{
			blobTimer = Random.Range(2f, 6.5f);
			var target = Instantiate(BlobTargetPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f)), Quaternion.Euler(0f, 0f, 0f));
			var blob = Instantiate(Blob, new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f), 1), Quaternion.Euler(0f, 0f, 0f));
			var blobScript = blob.GetComponentInChildren<BlobScript>();
			blobScript.Target = target;
			blobScript.Text.text = MarketBlobs[Random.Range(0, MarketBlobs.Length)];
			blobScript.SetBlobInitHealth(-1);
			blobScript.Difficulty = BlobScript.BlobDifficulty.MoveBackwards;
			blobScript.Behaviour = BlobScript.BlobBehaviour.MoveToTarget;
			blobScript.BlobSpeed = Random.Range(10f, 20f);
		}




	}
	public Dialogbox DialogBox;
	private Dictionary<int, bool> stuff;

	public void ShowDialog(int key, Dictionary<string, string> dict = null)
	{
		if(stuff.ContainsKey(key))
		{
			stuff[key] = true;
		}
		Dialogbox db = Instantiate(DialogBox, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
		db.Controller = this;
		db.ShowDialog(key, dict);
	}

	public override void Execute(string action, int[] param)
	{
		ShowDialog(param[0]);
	}

	IEnumerator WaitForFallingMilk()
	{
		float t = 0.0f;
		while (t <= 1)
		{
			if (!IsPaused)
			{
				t += Time.deltaTime;
			}
			yield return new WaitForEndOfFrame();
			print(t);
		}
		Milk.SetActive(true);
		ShowDialog(22);
		state = State.MilkDown;
		t = 0.0f;
		while (t <= 2)
		{
			if (!IsPaused)
			{
				t += Time.deltaTime;
			}
			yield return new WaitForEndOfFrame();
			print(t);
		}
		ShowDialog(23);
	}
}
