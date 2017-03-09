using UnityEngine;
using System.Collections;

public class leftTiltScript : MonoBehaviour
{
	//Static variable (global variable)
	public static bool isTiltingLeft = false;
	
	//Sets the tilt left animation trigger to true
	void OnTriggerStay2D(Collider2D ball)
	{
		if (ball.gameObject.tag == "ball")
			isTiltingLeft = true;
	}

	//When the ball leaves sets the trigger to false
	void OnTriggerExit2D(Collider2D ball)
	{
		if (ball.gameObject.tag == "ball")
			isTiltingLeft = false;
	}
}
