using UnityEngine;
using System.Collections;

/*Basically, since I have nowhere to test this...
 * I'll be calling it test1 for now
 * Version 0.1 
 * 24.02.2014
*/
public class TiltTest1Script : MonoBehaviour 
{
	public float TiltSpeed = 1.0f;
	public float i = 0;
	void Update() 
	{
		//Grabs value from the X coordinate from the iOS device accelerometer
		float tiltAngle = Input.acceleration.x + i;

		//Things we might use to make it feel balanced and fluid
		tiltAngle *= Time.deltaTime;

		//TiltSpeed = Weight*0.1f for example.
		tiltAngle *= TiltSpeed;

		GetComponent<Rigidbody2D>().AddTorque(tiltAngle);
		
	}
}
