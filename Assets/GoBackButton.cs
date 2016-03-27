using UnityEngine;
using System.Collections;

public class GoBackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClick() {
        Application.LoadLevel("MainMenu");
    }
}
