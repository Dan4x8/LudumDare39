using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript2 : MonoBehaviour {
	public enum OnClickBehaviour {Shrink,MoveBackwards, Split, None}
	public enum BlobDefeatCondition {NumberNclicks, OutOFBorder}
	public enum BlobBehaviour { None, Target, MoveToTarget, Grow}

	public TextMesh Text;
	public SpriteRenderer Background;

	public OnClickBehaviour Difficulty = OnClickBehaviour.MoveBackwards;
	public BlobBehaviour Behaviour = BlobBehaviour.None;
	public BlobDefeatCondition DefeatCondition = BlobDefeatCondition.NumberNclicks;


	public BlobTarget Target;

	public float BlobSpeed = 1f;
	public int BlobInitHealth = 1;
	public float BlobSetbackMod = 5;


	private int _blobHealth = 1;
	private Vector3 _initPos;

	// Use this for initialization
	void Start ()
	{
		_initPos = transform.position;

		if (BlobInitHealth != -1)
		{
			_blobHealth = BlobInitHealth;
		}

		Background.transform.localScale = new Vector3((Text.text.Length*Text.characterSize*Text.characterSize), 1f, 1f);

		switch(Behaviour)
		{
		case BlobBehaviour.Target:
			transform.position = Target.transform.position;
			break;
		default:
			break;
		}
	}





	public void FixedUpdate()
	{
		switch(Behaviour)
		{
		case BlobBehaviour.MoveToTarget:
			if (transform.position != Target.transform.position)
			{
				var speed = BlobSpeed*.1f;
				float step = speed * Time.fixedDeltaTime;
				transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
			}
			break;
		default:
			break;
		}
			
	}

	// kills blob if out of border
	void OnCollisionExit (Collision2D otherCollider) {
		if ( DefeatCondition == BlobDefeatCondition.OutOFBorder  && otherCollider.transform.tag == "Border"){
			Destroy (this);
		}
	}


	public void OnMouseDown()
	{
		switch(Difficulty)
		{
		case OnClickBehaviour.MoveBackwards:
			float speed = BlobSpeed * .1f;
			float step = speed * Time.fixedDeltaTime * BlobSetbackMod;
			Vector3 direction = Target.transform.position - transform.position;
			if(direction == Vector3.zero)
			{
				direction = new Vector3(Random.Range(1.5f, 2.5f), Random.Range(1.5f, 2.5f))*5;
			}
			transform.position -= direction * step;

			DecreaseHealth();
			break;

		default:
			_blobHealth = 0;
			break;
		}
		if(_blobHealth <= 0)
		{
			Destroy (this);
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

