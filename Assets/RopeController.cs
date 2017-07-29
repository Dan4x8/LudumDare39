using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RopeController : MonoBehaviour
{
	public Dialogbox DialogBox;
	public SpriteRenderer Whitening;

	public SpriteRenderer Rope;

	private void OnMouseDown()
	{
		/*
		Dialogbox db = Instantiate(DialogBox, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
		db.ShowDialog(3);
		*/

		transform.localScale *= 1.1f;
		Whitening.color *= new Vector4(1f, 1f, 1f, 1.5f);
		Whitening.transform.localScale *= 1.2f;

		Rope.color *= new Vector4(1.25f, 1.25f, 1.25f, 1f);

		if(Whitening.color.a >= 1.2f)
		{
			SceneManager.LoadScene("Bedroom");
		}
	}
}
