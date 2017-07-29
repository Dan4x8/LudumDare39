using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
	public Dialogbox DialogBox;

	private void OnMouseDown()
	{
		Dialogbox db = Instantiate(DialogBox, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
		db.ShowDialog(3);
	}
}
