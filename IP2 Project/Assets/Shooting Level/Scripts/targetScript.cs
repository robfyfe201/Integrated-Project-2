using UnityEngine;
using System.Collections;

public class targetScript : MonoBehaviour
{
	private float hInput; //Testing controls
	public float targetSpeed = 10.0f; //Amount of force added to the target with < and >
	public float maxtargetSpeed = 10.0f; //Maximum target velocity
	public float weightSpeed = -0.5f; //Force aplied at the beginning depending on weight balance

	void Awake()
	{
		//Add force at the begining depending on the weight
		GetComponent<Rigidbody2D>().velocity = new Vector2 (weightSpeed , GetComponent<Rigidbody2D>().velocity.y);
	}

	// Update is called once per frame
	void Update () 
	{
	}

	//Physics update
	void FixedUpdate()
	{
		//Checks the ball's current speed and adjusts it accordingly
		if (GetComponent<Rigidbody2D>().velocity.x < 0)
				GetComponent<Rigidbody2D>().AddForce(new Vector2 ((targetSpeed), GetComponent<Rigidbody2D>().velocity.y));


		//... if the ball is already going too fast, adjust it's speed to equal the max velocity
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (maxtargetSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
