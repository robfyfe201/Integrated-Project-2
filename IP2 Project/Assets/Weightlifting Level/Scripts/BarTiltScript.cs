using UnityEngine;
using System.Collections;

public class BarTiltScript : MonoBehaviour
{
	private float hInput; //Testing controls
	public float ballSpeed = 50.0f; //Amount of force added to the ball with < and >
	public float maxBallSpeed = 10.0f; //Maximum ball velocity
	public float weightSpeed = -5.0f; //Force aplied at the beginning depending on weight balance

	void Awake()
	{

		//Add force at the begining depending on the weight
		GetComponent<Rigidbody2D>().velocity = new Vector2 (weightSpeed , GetComponent<Rigidbody2D>().velocity.y);
	}

	// Update is called once per frame
	void Update () 
	{

		//Gets value between -1..1 from the left and right arrows
		hInput = Input.GetAxis ("Horizontal");
	}

	//Physics update
	void FixedUpdate()
	{
		//Checks the ball's current speed and adjusts it accordingly
		if (GetComponent<Rigidbody2D>().velocity.x < maxBallSpeed)
				GetComponent<Rigidbody2D>().AddForce(new Vector2 ((hInput * ballSpeed), GetComponent<Rigidbody2D>().velocity.y));

		//... if the ball is already going too fast, adjust it's speed to equal the max velocity
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (maxBallSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
