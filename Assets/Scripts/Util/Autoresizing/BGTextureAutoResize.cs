using UnityEngine;
using System.Collections;

/// <summary>
/// Auto resize a 2D texture to take up the entire screen
/// </summary>
public class BGTextureAutoResize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Set the game object's scale to the same dimensions as the screen
		gameObject.transform.localScale = new Vector3(Screen.width, Screen.height, 1);
	}
}
