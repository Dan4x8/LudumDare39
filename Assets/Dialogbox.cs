using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogbox : MonoBehaviour
{
	public Controller Controller;
	public Text TxtName;
	public Text TxtText;

	public string DialogFile = "dlgTest";

	public void Awake()
	{
		GameObject[] olds = GameObject.FindGameObjectsWithTag("MessageBox");
		if(olds.Length > 1)
		{
			foreach (GameObject old in olds)
			{
				if (old != gameObject)
				{
					old.GetComponent<Dialogbox>().Close();
				}
			}
		}
	}

	public void ShowDialog(int key)
	{
		if(Controller && Controller.PauseTimer)
		{
			Controller.IsPaused = true;
		}
		key = key - 1;
		string[] lines = ((TextAsset)Resources.Load(DialogFile, typeof(TextAsset))).text.Split('\n');

		string[] text = lines[key].Split(';');
		TxtText.text = text[1].Replace("\\n", "\n");
		TxtName.text = text[0];
	}

	public void Close()
	{
		if(Controller && Controller.PauseTimer)
		{
			Controller.IsPaused = false;
		}
		Destroy(gameObject);
	}
}
