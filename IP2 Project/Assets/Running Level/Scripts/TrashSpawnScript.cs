using UnityEngine;
using System.Collections;

public class TrashSpawnScript : MonoBehaviour 
{
	//Public variables
	public Rigidbody2D trash; //Asign prefab to be spawned by the script
	public int maxTrash = 10; //Limits the amount of trash objects at any time
	public float spawnDelay; //Time between each spawn in seconds
	public GameObject[] locations; //Private array used to set up locations at which the trash can spawn

	//Private variables
	public static int curTrashSpawned = 0; //Current trash in the game world

	//Called at the start duh
	IEnumerator Start()
	{
		yield return StartCoroutine (Spawn ());
	}

	//Called once per frame
	IEnumerator Spawn()
	{
		while (!GUIScript.timeOver && curTrashSpawned < maxTrash)
		{
			yield return new WaitForSeconds (spawnDelay);
			Rigidbody2D trashSpwn = Instantiate (trash,locations[Random.Range (0, (locations.Length))].transform.position,
			                                     Quaternion.identity) as Rigidbody2D;
			curTrashSpawned++;
		}

	}

	//Called once per frame
	void Update()
	{
		spawnDelay = 2 - (GUIScript.score / 30);
	}

/*	//Method that does the actual spawning
	void SpawnTrash()
	{
		Rigidbody2D trashSpwn = Instantiate (trash,locations[Random.Range (0, (locations.Length - 1))].transform.position,
		                                     Quaternion.identity) as Rigidbody2D;
		curTrashSpawned++;
	}
*/
}