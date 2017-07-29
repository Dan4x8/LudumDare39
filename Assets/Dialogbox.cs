using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogbox : MonoBehaviour
{
	public Text TxtName;
	public Text TxtText;

	public string DialogFile = "dlgTest";

	public void ShowDialog(int key)
	{
		key = key - 1;
		string[] lines = ((TextAsset)Resources.Load(DialogFile, typeof(TextAsset))).text.Split('\n');

		string[] text = lines[key].Split(';');
		TxtText.text = text[1].Replace("\\n", "\n");
		TxtName.text = text[0];
	}
}
