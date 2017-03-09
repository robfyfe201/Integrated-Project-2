using UnityEngine;
using System.Collections;

public class ControlsV2_Axis : MonoBehaviour 
{
	//GUI Textures for buttons
	public GUITexture LeftButton;
	public GUITexture RightButton;
	public GUITexture JumpButton;
	
	//Public variables
	public float maxVelocity = 5.0f; //Limits the velocity
	public float moveForce = 50.0f; //The amount of force applied when moving in either direction
	public float jumpForce = 100.0f; //The amount of force applied when jumping

	//Private variables
	//private bool isFaceingRight = true; //Stores information about which direction the object is facing, Currently not in use
	private bool isJumping; //Stores infromation about the jump flag
	private bool grounded; //Stores information about player colliding with the ground
	private float moveDirection; //Stores a possitive or negative float used to determine direction



	// Update is called once per frame
	void Update () 
	{
		//If up arrow is pressed and the player is on the ground, jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded)
			isJumping = true;

		//Check for touches
		if (Input.touchCount > 0) 
		{
			//Stores touch Info
			Touch touch = Input.GetTouch (0);
			
			//Check if touch began
			if(touch.phase == TouchPhase.Began)
			{
				//If left button touched set move direction to a negative value
				if(LeftButton.HitTest(touch.position, Camera.main))
					moveDirection = -1.0f;

				//If right button touched set move direction to a positive value
				if(RightButton.HitTest(touch.position, Camera.main))
					moveDirection = 1.0f;

				//If jump button touched set jumpAway flag to true
				if(JumpButton.HitTest(touch.position, Camera.main))
					isJumping = true;
			}

			//Check if touch ended
			if(touch.phase == TouchPhase.Ended)
			{
				moveDirection = 0.0f;
			}
		}
		
		//Check if left mouse button is pressed
		if(Input.GetMouseButtonDown(0))
		{
			//If left button clicked set move direction to a negative value
			if(LeftButton.HitTest(Input.mousePosition, Camera.main))
				moveDirection = -1.0f;

			//If right button clicked set move direction to a positive value
			if(RightButton.HitTest(Input.mousePosition, Camera.main))
				moveDirection = 1.0f;

			//If jump button clicked set jumpAway to true
			if(JumpButton.HitTest(Input.mousePosition, Camera.main))
				isJumping = true;
		}

		//Check if left mouse button is released
		if (Input.GetMouseButtonUp (0)) 
		{
			moveDirection = 0.0f;
		}
	}

	void FixedUpdate()
	{
		//Stores info about Left or Right arrows being pressed, info is stored as a float -1..1
		float hInput = Input.GetAxis ("Horizontal");

		//If the player is changing directions or hasn't reached the maximum velocity
		if (hInput * GetComponent<Rigidbody2D>().velocity.x < maxVelocity)
			//...add force to the player in the "hInput" direction
				GetComponent<Rigidbody2D>().AddForce (Vector2.right * hInput * moveForce);
		//If the player presses the left arrow hInput's value is -1, meaning force is applied 
		//left, and if the right arrow is pressed hInput is 1, meaning force is applied right

		//If the absolute value (regardless of it's sign durr) of the horizontal velocity of the
		//object is higher than the maximum velocity
		if (Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x) > maxVelocity)
			//...change the object's velocity to equal the maximum velocity
				GetComponent<Rigidbody2D>().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D>().velocity.x) * maxVelocity,
			                                     GetComponent<Rigidbody2D>().velocity.y);

		//If the left button has been clicked/touched and move direction has been set to a value
		if (moveDirection * GetComponent<Rigidbody2D>().velocity.x < maxVelocity)
			//...apply force in that direction
				GetComponent<Rigidbody2D>().AddForce (Vector2.right * moveDirection * moveForce);

		//If the player is jumping
		if (isJumping) 
		{
			//Apply vertical force to the player, a.k.a. jump
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));

			//Prevent the player from jumping again, untill the conditions are met (grounded & jump button/key pressed)
			isJumping = false;
		}
	}

	//Checks if the player is touching the ground
	void OnCollisionEnter2D (Collision2D theCollision)
	{
		if (theCollision.gameObject.tag == "Ground")
			grounded = true;
	}

	//Checks if player is not touching the ground
	void OnCollisionExit2D (Collision2D theCollision)
	{
		if (theCollision.gameObject.tag == "Ground")
			grounded = false;
	}



}
