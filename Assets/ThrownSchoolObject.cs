using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ThrownSchoolObject : MonoBehaviour {

	public GameObject TargetPoint;
	public float TimeToTarget = 1f;
	public Vector3 MaxScale = new Vector3(9f, 9f, 9f);
	public float Threshold = .8f;

	private Vector3 Target;
	private Vector3 StartingPoint;
	private SpriteRenderer Sprite;
	private Color OriginalColor;

	// Use this for initialization
	void Start ()
	{
		Target = TargetPoint.transform.position;
		//Target = new Vector3(Target.x, Target.y, -1);
		transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-.5f, 4f),-1);
		StartingPoint = transform.position;
		Sprite = GetComponent<SpriteRenderer>();
		OriginalColor = Sprite.color;
	}

	public void FixedUpdate()
	{
		if(t > TimeToTarget)
		{
			Destroy(gameObject);
		}

		if (!Sprite)
		{
			return;
		}
		t += Time.deltaTime / TimeToTarget;
		transform.position = Vector3.Lerp(StartingPoint, Target, t);
		Sprite.color = Color.Lerp(OriginalColor, new Color(OriginalColor.r, OriginalColor.g, OriginalColor.b, 1f), t);
		transform.localScale = Vector3.Lerp(Vector3.one, MaxScale, t);
	}

	float t;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (t / TimeToTarget >= Threshold)
		{
			print("TRIGGERED");
		}
	}
}
