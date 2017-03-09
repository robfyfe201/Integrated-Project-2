using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D playerObj)
	{
		if (playerObj.gameObject.tag == "Player")
		{
			GUIScript.score++;
			TrashSpawnScript.curTrashSpawned--;
			Destroy (this.gameObject);
		}
	}
}
