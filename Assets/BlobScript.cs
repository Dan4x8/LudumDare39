using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript : MonoBehaviour {
	public enum BlobDifficulty { ClickNTimes,MoveBackwards}
	public enum BlobBehaviour { None, Target, MoveToTarget}

	public TextMesh Text;
	public SpriteRenderer Background;

	public BlobDifficulty Difficulty = BlobDifficulty.MoveBackwards;
	public BlobBehaviour Behaviour = BlobBehaviour.None;

	public BlobTarget Target;
	public float BlobSpeed = 1f;
	public int BlobInitHealth = 1;
	public float BlobSetbackMod = 50f;

	private int _blobHealth = 1;

	// Use this for initialization
	void Start ()
	{
		if (BlobInitHealth != -1)
		{
			_blobHealth = BlobInitHealth;
		}
		Parent = transform.parent.transform;

		Background.transform.localScale = new Vector3((Text.text.Length*Text.characterSize*Text.characterSize), 1f, 1f);

		switch(Behaviour)
		{
			case BlobBehaviour.Target:
				transform.parent.transform.position = Target.transform.position;
				break;
			default:
				break;
		}
	}

	Transform Parent;

	public void FixedUpdate()
	{
		switch(Behaviour)
		{
			case BlobBehaviour.MoveToTarget:
				if (Parent.position != Target.transform.position)
				{
					var speed = BlobSpeed*.1f;
					float step = speed * Time.fixedDeltaTime;
					Parent.position = Vector3.MoveTowards(Parent.position, Target.transform.position, step);
				}
				break;
			default:
				break;
		}
	}

	public void OnMouseDown()
	{
		switch(Difficulty)
		{
			case BlobDifficulty.MoveBackwards:
				float speed = BlobSpeed * .1f;
				float step = speed * Time.fixedDeltaTime * BlobSetbackMod;
				Vector3 direction = Target.transform.position - Parent.position;
				if(direction == Vector3.zero)
				{
					direction = new Vector3(Random.Range(1.5f, 2.5f), Random.Range(1.5f, 2.5f))*5;
				}
				Parent.position -= direction * step;

				DecreaseHealth();
				break;
			case BlobDifficulty.ClickNTimes:
				DecreaseHealth();
				break;
			default:
				_blobHealth = 0;
				break;
		}
		if(_blobHealth <= 0)
		{
			Destroy(Parent.gameObject);
		}
	}

	public void DecreaseHealth(int val = 1)
	{
		if(BlobInitHealth != -1)
		{
			_blobHealth-=val;
		}
	}

	private void OnDrawGizmos()
	{
		if (Target)
		{
			Gizmos.color = Target.Color;
			Gizmos.DrawLine(transform.position, Target.transform.position);
		}
	}
}
