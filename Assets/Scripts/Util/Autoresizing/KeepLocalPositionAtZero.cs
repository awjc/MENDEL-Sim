using UnityEngine;
using System.Collections;

public class KeepLocalPositionAtZero : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
    {
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
	}
}
