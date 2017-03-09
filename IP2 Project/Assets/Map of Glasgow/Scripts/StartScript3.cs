using UnityEngine;
using System.Collections;

public class StartScript3 : MonoBehaviour 

	{
		public GUITexture startButton;
		
		// Update is called once per frame
		void Update () {
			
			//makes the game start
			if(Input.GetMouseButtonDown(0))
			{
				
				if (startButton.HitTest(Input.mousePosition, Camera.main))
					Application.LoadLevel ("ShootingLevel");
			}
		}
	}
