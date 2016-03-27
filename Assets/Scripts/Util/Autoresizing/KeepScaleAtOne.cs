using UnityEngine;
using System.Collections;

public class KeepScaleAtOne : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);	
	}
}
