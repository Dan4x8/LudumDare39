using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

	public Controller Controller;
	public string Action = "Dialog";
	public int[] paramInt;

	private void OnMouseDown()
	{
		Controller.Execute(Action, paramInt);
	}

}

public abstract class Controller : MonoBehaviour
{
	public abstract void Execute(string action, int[] paramInt);
	public bool PauseTimer;
	public bool IsPaused;
}
