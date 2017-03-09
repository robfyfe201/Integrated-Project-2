using UnityEngine;
using System.Collections;

public class ButtonPlatformSides : MonoBehaviour
{
	//Public variables
	public GameObject movingPlatform;  //When the player triggers the button the object that moves is...
	public GameObject button; //The button the player presses
	public float directionSpeed = 2.0f;  //Speed at which the platform moves
	public float distance = 4.0f;  // Distance the platform travels
	public float buttonSinkSpeed = 2.0f; //Speed at which the button sinks

	//Private variables
	private float originalPosition; //Original platform position
	public static float useSpeed; //Sexier code...
	private bool platTriggered = false; //Platform trigger bool
	private float buttonSinkDistance = 0.3f; //Distance the button will sink
	private float buttonOriginalPosition;

	//Triggers when the object is first instantiated
	void Awake()
	{
		originalPosition = movingPlatform.transform.position.x;
		buttonOriginalPosition = button.transform.position.y;
		useSpeed = -directionSpeed;
	}
	
	//Triggers once per frame
	void Update()
	{
		//Check if platform is triggered
		TriggerPlatform ();
	}
	
	//When the player triggers the button this happens...
	void OnTriggerStay2D()
	{
		//Make the button sink in
		if(button.transform.position.y < buttonOriginalPosition + buttonSinkDistance)
			button.transform.Translate (0, -buttonSinkSpeed * Time.deltaTime, 0);

		//Trigger the platform
		platTriggered = true;
		button.GetComponent<Collider2D>().enabled = false;
	}

	//Move the platform if it's triggered
	void TriggerPlatform()
	{
		//Check if platform is triggered
		if (platTriggered)
		{

			//Flip direction when destination is reached
			if (originalPosition - movingPlatform.transform.position.x > distance)
				useSpeed = directionSpeed;
			else if (originalPosition - movingPlatform.transform.position.x < -distance)
				useSpeed = -directionSpeed;

			//Translate the platform 
			movingPlatform.transform.Translate (useSpeed * Time.deltaTime, 0, 0);
		} 
	}
}
