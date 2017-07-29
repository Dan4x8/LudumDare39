using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogbox : MonoBehaviour
{
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
					DestroyImmediate(old);
				}
			}
		}
	}

	public void ShowDialog(int key)
	{
		key = key - 1;
		string[] lines = ((TextAsset)Resources.Load(DialogFile, typeof(TextAsset))).text.Split('\n');

		string[] text = lines[key].Split(';');
		TxtText.text = text[1].Replace("\\n", "\n");
		TxtName.text = text[0];
	}

	public void Close()
	{
		Destroy(gameObject);
	}
}
