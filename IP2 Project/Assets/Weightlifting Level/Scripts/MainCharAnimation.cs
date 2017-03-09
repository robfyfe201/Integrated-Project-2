using UnityEngine;
using System.Collections;

public class MainCharAnimation : MonoBehaviour 
{
	private Animator anim; //Animator temp variable, cause C#
	private bool tiltLeft = false; //Red zone left trigger
	private bool tiltRight = false; //Red zone right trigger
	private bool dropDead = false; //Drop animation trigger

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () 
	{
		//Check if player is in the left red zone
		if (leftTiltScript.isTiltingLeft)
			//...if true trigger animation
			tiltLeft = true;
		//otherwise do nothing
		else
			tiltLeft = false;

		//Check if player is in the right red zone
		if (rightTiltScript.isTiltingRight)
			//...if true trigger animation
			tiltRight = true;
		//otherwise do nothing
		else
			tiltRight = false;

		//YOU DEAD SAWN!
		if (dropDeadScript.youDEADsawn)
			dropDead = true;
	}

	//This happens after update
	void LateUpdate()
	{
		//Sets animation triggers
		anim.SetBool ("tiltingLeft", tiltLeft);
		anim.SetBool ("tiltingRight", tiltRight);
		anim.SetBool ("Drop", dropDead);
	}

	//DEAH!
	private void YouDeadDawg()
	{
		if (dropDead)
		{
			print ("Game over screen");
		}
	}


}
