using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour 
{

	//Public variables
	public GUISkin buttonSkin; //Changes the skin the buttons and boxes in the pause menu use

	//Private variables
	public static bool pauseMenuEnabled = false;

	//Triggers every time the object holding the script is instantiated
	void Start()
	{
		Time.timeScale = 1;
		pauseMenuEnabled = false;
		AudioListener.volume = 1;
	//	Screen.showCursor = false;
	}

	//Triggers once per frame
	void Update()
	{
		//When you press escape...
		if(Input.GetKeyDown(KeyCode.Escape) )
		{
			Temp ();
		}
	}

	void Temp()
	{
		if(!pauseMenuEnabled)
		{
			pauseMenuEnabled = true;
			AudioListener.volume = 0;
			Time.timeScale = 0;
		}

		else
		{
			pauseMenuEnabled = false;
			AudioListener.volume = 1;
			Time.timeScale = 1;
		}

	}

	//Unity in-built GUI system
	void OnGUI()
	{

		//Set the buttons and boxes skin
		GUI.skin = buttonSkin;

		//Pause button
		if(GUI.Button(new Rect((Screen.width/2) ,(Screen.height - 100),200 ,50), "Pause Game"))
		{
			Temp ();

		}

		//If the Menu is enabled draw this stuff
		if(pauseMenuEnabled)
		{

			//Menu background
			GUI.Box(new Rect((Screen.width/2 - Screen.height/2),250 ,(Screen.width/2) ,(Screen.height/2) ), "Pause");

			//Continue button
			if(GUI.Button(new Rect((Screen.width/2), (Screen.height/2), 200, 50), "Continue")) {Temp ();}

			//Main menu button
			if(GUI.Button(new Rect((Screen.width/2  - Screen.height/2) ,650 ,200 ,50), "Main Menu"))	
			{
				Application.LoadLevel("MenuScene");

				//If the current loaded application is the running level stuff happens
				if(Application.loadedLevelName == "RunningLevel")
				{
					GUIScript.timeOver = false;
					GUIScript.score = 0.0f;
				}
			}
	
			//Quit button
			if(GUI.Button(new Rect((Screen.width/2 - Screen.height/2) ,700 ,200 ,50), "Quit Game"))	{Application.Quit();}

		}
	}

}
