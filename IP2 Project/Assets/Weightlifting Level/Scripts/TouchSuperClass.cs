using UnityEngine;
using System.Collections;

public class TouchSuperClass : MonoBehaviour 
{
	//Represents current touch, can be viewed from other scripts
	public static int currentTouch;

	//Checks for touches on the screen, call in Update() to check for touches
	public void CheckForTouches()
	{
		//if no touches happening call this method, scroll down for more info
		if (Input.touches.Length <= 0) 
		{
			NoTouches ();
		}

		//if touches detected go through all of them 
		else 
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				//Sets currentTouch variable to equal the current touch.
				currentTouch = i;

				if(this.GetComponent<GUITexture>() != null && (this.GetComponent<GUITexture>().HitTest(Input.GetTouch(i).position)))
				{
					//When the touch begins
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						OnTouchBegin();
					}

					//When the touch ends
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						OnTouchEnd();
					}
				}
			}
		}
	}
	public virtual void NoTouches(){}
	public virtual void OnTouchBegin(){}
	public virtual void OnTouchEnd(){}
}