using UnityEngine;
using System.Collections;

public static class TwoButtonDelegator 
{
	private const int LEFT_MOUSE = 0;
	private const int RIGHT_MOUSE = 1;

	public static bool GetGrowButton()
	{
		bool a = Input.GetKey(KeyCode.UpArrow);
		bool b = Input.GetKey(KeyCode.W);

		bool touchInitiate = Input.GetMouseButton(LEFT_MOUSE);
		bool touchLocation = Input.mousePosition.y > Screen.height/2;
		bool t = touchInitiate && touchLocation;

		return a || b || t;
	}

	public static bool GetShrinkButton()
	{
		bool a = Input.GetKey(KeyCode.DownArrow);
		bool b = Input.GetKey(KeyCode.S);

		bool touchInitiate = Input.GetMouseButton(LEFT_MOUSE);
		bool touchLocation = Input.mousePosition.y < Screen.height/2;
		bool t = touchInitiate && touchLocation;

		return a || b || t;
	}
}
