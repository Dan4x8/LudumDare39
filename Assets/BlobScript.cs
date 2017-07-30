using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript : MonoBehaviour {
	public enum BlobDifficulty { ClickOnce}

	public TextMesh Text;
	public SpriteRenderer Background;
	public BlobDifficulty Difficulty = BlobDifficulty.ClickOnce;

	// Use this for initialization
	void Start ()
	{
		Background.transform.localScale = new Vector3((Text.text.Length*Text.characterSize*Text.characterSize), 1f, 1f);
	}

	public void OnMouseDown()
	{
		switch(Difficulty)
		{
			case BlobDifficulty.ClickOnce:
				Destroy(transform.parent.gameObject);
				break;
			default:
				break;
		}
	}
}
