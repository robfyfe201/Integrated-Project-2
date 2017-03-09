using UnityEngine;
using System.Collections;

//Inharit from TouchSuperClass instead of MonoBehaviour!!!
public class ExampleButtonScript : TouchSuperClass 
{
	//Useful for cinematics, end screen, etc.
	public bool disableTouch = false;

	// Update is called once per frame
	void Update () 
	{
		//If disableTouch is false check for touches
		if (!disableTouch) 
		{
			CheckForTouches();
		}
	}

	//Don't do what OnTouchBegin does in TouchSuperClass, do this instead
	public override void NoTouches()
	{
		print ("Example code goes here");
	}

	//Don't do what OnTouchBegin does in TouchSuperClass, do this instead
	public override void OnTouchBegin()
	{
		print ("Example code goes here");
	}

	//Don't do what OnTouchEnds does in TouchSuperClass, do this instead
	public override void OnTouchEnd()
	{
		print ("Example code goes here");
	}
}
