using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//Public variables
	public GameObject target; //Object the camera follows
	public float leftLimit; //Limits how far the camera goes
	public float rightLimit; //Limits how far the camera goes
	
	// Update is called once per frame
	void Update () 
	{
		//Temporary variables for transform.position
		Vector3 temp = transform.position;
		Vector3 tempTarget = target.transform.position;

		if(tempTarget.x > leftLimit && tempTarget.x < rightLimit)
		{
			//Change the camera's position to match the target's position
			temp.x = tempTarget.x;
			transform.position = temp;
		}
	}


}
