using UnityEngine;
using System.Collections;

public class CursorIcon : MonoBehaviour {
	
	private float z;
	
	void Start () {
		Cursor.visible = false;
		z = transform.position.z;
	}
	
	void Update () {
		float x = Input.mousePosition.x / Screen.width;
		float y = Input.mousePosition.y / Screen.height;
		transform.position = new Vector3 (x, y, z);	
	}
}