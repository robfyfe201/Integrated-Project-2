using UnityEngine;
using System.Collections;

public class PlatformsFixScript : MonoBehaviour
{

	void OnTriggerStay2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player") 
		{
		//	player.gameObject.rigidbody2D.AddForce(new Vector2 (ButtonPlatformSides.useSpeed * 23, 0));

			player.gameObject.transform.Translate(ButtonPlatformSides.useSpeed * Time.deltaTime, 0.0f, 0.0f);
		}
	}
}
