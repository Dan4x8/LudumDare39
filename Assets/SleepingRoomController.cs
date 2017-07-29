using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepingRoomController : Controller {

	public Dialogbox DialogBox;

	void Start ()
	{
		PauseTimer = true;
		ShowDialog(4);
		StartCoroutine(WaitForSchool());
	}

	public void ShowDialog(int key)
	{
		Dialogbox db = Instantiate(DialogBox, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
		db.Controller = this;
		db.ShowDialog(key);
	}

	public override void Execute(string action, int[]param)
	{
		ShowDialog(param[0]);
	}

	IEnumerator WaitForSchool()
	{
		float t = 0.0f;
		while (t <= 10)
		{
			if (!IsPaused)
			{
				t += Time.deltaTime;
			}
			yield return new WaitForEndOfFrame();
			print(t);
		}
		ShowDialog(8);
		while (IsPaused)
			yield return new WaitForEndOfFrame();
		SceneManager.LoadScene("Classroom");
	}

}
