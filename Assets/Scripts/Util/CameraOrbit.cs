using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
    public bool _enabled;
    public Vector3 orbitCenter;
	public float degreesPerSecond;
	public bool clockwise;
	
	private Vector3 origPosition;
	private float thetaDeg;

	void Start()
	{
		origPosition = transform.position;
		thetaDeg = Mathf.Rad2Deg * Mathf.Atan2 (origPosition.z, origPosition.x);
	}

	// Update is called once per frame
	void Update () {
        if (_enabled)
        {
            thetaDeg = (thetaDeg + (clockwise ? -1 : 1) * degreesPerSecond * Time.deltaTime) % 360.0f;

            float xPos = Mathf.Cos(Mathf.Deg2Rad * thetaDeg) * origPosition.magnitude;
            float zPos = Mathf.Sin(Mathf.Deg2Rad * thetaDeg) * origPosition.magnitude;

            gameObject.transform.position = new Vector3(xPos, gameObject.transform.position.y, zPos);
            gameObject.transform.LookAt(orbitCenter);
        }
	}
}
