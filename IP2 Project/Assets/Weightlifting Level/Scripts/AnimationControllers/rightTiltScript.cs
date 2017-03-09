using UnityEngine;
using System.Collections;

public class rightTiltScript : MonoBehaviour
{
	//Static variable (global variable)
	public static bool isTiltingRight = false;
	
	//Sets the tilt left animation trigger to true
	void OnTriggerStay2D(Collider2D ball)
	{
		if (ball.gameObject.tag == "ball")
			isTiltingRight = true;
	}
	
	//When the ball leaves sets the trigger to false
	void OnTriggerExit2D(Collider2D ball)
	{
		if (ball.gameObject.tag == "ball")
			isTiltingRight = false;
	}
}

