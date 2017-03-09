using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	//Global variables
	public float timeLimit = 60; //Total time limit the player has in seconds
	public static float score = 0; //Player score
	public static bool timeOver = false; //Time out

	//GUIText variables
	public GUIText scoreGUI;
	public GUIText timeLeftGUI;

	//Variables for testing purposes
	public int scoreMonitor;
	public bool timeOverMonitor;

	// Use this for initialization
	IEnumerator Start () 
	{
		yield return StartCoroutine (TimeLimit ());
	}
 
	//Time limit counter
	IEnumerator TimeLimit()
	{
		yield return new WaitForSeconds (timeLimit);
		timeOver = true;
	}

	void Update()
	{
		//DERP
		timeLimit -= Time.deltaTime;

		//GUI set up
		scoreGUI.text = " " + score;
		if (!timeOver)
			timeLeftGUI.text = " " + Mathf.Round (timeLimit);
		else
			timeLeftGUI.text = " X";

		//If time's over pause the game with the score screen or smthing els
		if(timeOver)
			PauseMenuScript.pauseMenuEnabled = true;
	}
}
