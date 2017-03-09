using UnityEngine;
using System.Collections;

/* Summary v0.1 YOUDEADSAWN script
 * Written by Donn Tonny de la Mancha
 * 07/03/2014 M606
 * NOT FINISHED MOFO!"
 * */

public class dropDeadScript : MonoBehaviour
{
	//Static variable (global variable)
	public static bool youDEADsawn = false;
	
	//Sets the tilt left animation trigger to true
	void OnTriggerStay2D(Collider2D ball)
	{
		if (ball.gameObject.tag == "ball")
			youDEADsawn = true;
	}
	
	//When the ball leaves sets the trigger to false
	void OnTriggerExit2D(Collider2D ball)
	{
		if (ball.gameObject.tag == "ball")
			youDEADsawn = false;
	}
}
