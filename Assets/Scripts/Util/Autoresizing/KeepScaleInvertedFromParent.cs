using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class KeepScaleInvertedFromParent : MonoBehaviour 
{
    // Update is called once per frame
	void Update () 
    {
        if (transform.parent != null)
        {
            float scaleX = transform.parent.localScale.x != 0 ? 1 / transform.parent.localScale.x : 0;
            float scaleY = transform.parent.localScale.y != 0 ? 1 / transform.parent.localScale.y : 0;
            float scaleZ = transform.parent.localScale.z != 0 ? 1 / transform.parent.localScale.z : 0;

            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
		//	Debug.Log("SETTING SCALE: " + transform.localScale);
        }
	}
}
