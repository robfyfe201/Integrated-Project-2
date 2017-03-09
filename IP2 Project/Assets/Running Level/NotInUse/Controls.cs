using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	//Textures/Buttons
	public GUITexture Left;
	public GUITexture Right;
	public GUITexture Jump;

	//Magnitudes
	public float moveSpeed = 5.0f;
	public float jumpForce = 50.0f;
	public float maxJumpVelocity = 2.0f;

	//Movement flags
	private bool moveLeft;
	private bool moveRight;
	private bool jumpAway;
	

	// Update is called once per frame
	void Update () 
	{

		//Check for touches
		if (Input.touchCount > 0) 
		{
			//Touch Info
			Touch touch = Input.GetTouch (0);

			//Check if touch just began
			if(touch.phase == TouchPhase.Began)
			{
				//If left button touched set moveLeft flag to true
				if(Left.HitTest(touch.position, Camera.main))
					moveLeft = true;


				//If right button touched set moveRight flag to true
				 if(Right.HitTest(touch.position, Camera.main))
					moveRight = true;
				

				//If jump button touched set jumpAway flag to true
				if(Jump.HitTest(touch.position, Camera.main))
					jumpAway = true;
			}

			//Check if touch just ended
			if(touch.phase == TouchPhase.Ended)
			{
				//Stop all movement 
				jumpAway = moveLeft = moveRight = false;
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
		}

		//Check if left mouse button is pressed
		if(Input.GetMouseButtonDown(0))
		{
			//If left button clicked set moveLeft flag to true
			if(Left.HitTest(Input.mousePosition, Camera.main))
				moveLeft = true;


			//If right button clicked set moveLeft to true
			if(Right.HitTest(Input.mousePosition, Camera.main))
				moveRight = true;
			

			//If jump button clicked set jumpAway to true
			if(Jump.HitTest(Input.mousePosition, Camera.main))
				jumpAway = true;
		}
		
		//Check if left mouse button is released
		if(Input.GetMouseButtonUp(0))
		{
			//stop all movement
			jumpAway = moveLeft = moveRight = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		//Check if left arrow is pressed and move left
		if (Input.GetKeyDown (KeyCode.LeftArrow))
			moveLeft = true;
			
		//check if right arrow is pressed and move right
		if (Input.GetKeyDown (KeyCode.RightArrow))
			moveRight = true;	

		//Check if space bar is pressed and jump
		if (Input.GetKeyDown (KeyCode.UpArrow))
			jumpAway = true;

		//Check if left arrow is released and stop movement
		if (Input.GetKeyUp (KeyCode.LeftArrow))
		{
			moveLeft = false;
			jumpAway = false;
			moveRight = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		//Check if right arrow is released and stop movement
		if (Input.GetKeyUp (KeyCode.RightArrow))
		{
			moveLeft = false;
			jumpAway = false;
			moveRight = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		//Check if spacebar is released and stop applying "jump" force
		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			jumpAway = false;
		}
	}

	void FixedUpdate()
	{

		//If moveLeft flag is up, move left
		if (moveLeft) 
			GetComponent<Rigidbody2D>().velocity = -Vector2.right * moveSpeed;

		//If moveRight flag is up, move right
		if (moveRight)
			GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;

		//If jumpAway flag is up, jump
		if (jumpAway) 
						GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpForce);

			//If MaxJumpVelocity has been reached, stop applying "jump" force
		else 
		{
			jumpAway = false;
		}

	}

}

