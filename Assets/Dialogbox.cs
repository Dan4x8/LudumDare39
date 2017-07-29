using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogbox : MonoBehaviour {

	Image imgTextBackground;
	Image imgNameBackground;

	// Use this for initialization
	void Start ()
	{
		Image[] imgs = GetComponentsInChildren<Image>();
		imgTextBackground = imgs[0];

		//SetTransparency(0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTransparency(float alpha)
	{
		imgTextBackground.color = new Color(imgTextBackground.color.r, imgTextBackground.color.g, imgTextBackground.color.b, alpha);
	}
}
