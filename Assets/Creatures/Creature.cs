using UnityEngine;
using System.Collections;
using Assets.Scripts.Util;
using System.Xml;
using System.Xml.Serialization;

public class Creature : MonoBehaviour 
{
	public string Name;

    public BodySegment _rootSegment; //changed this to public

	public GameObject JointConnectionPrefab;

	// Use this for initialization
	void Start () 
    {
//        _rootSegment = new BodySegment();
//        Util.Parent(_rootSegment.GameObj, gameObject);
//        _rootSegment.GameObj.transform.localPosition = new Vector3(0, 0, 0);
//        _rootSegment.GameObj.AddComponent<Rigidbody>();
//        var rb = _rootSegment.GameObj.GetComponent<Rigidbody>();
//        rb.useGravity = false;
//        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
//
//
//        BodySegment seg = new BodySegment();
//
//		GameObject joint1 = (GameObject) Instantiate (JointConnectionPrefab, new Vector3(0, 0, 0), Quaternion.identity);
//		joint1.GetComponent<FixedJoint>().connectedBody = _rootSegment.GameObj.GetComponent<Rigidbody>();
////        seg.GameObj.AddComponent<JointConnectionPrefab>();
//        JointMotor joint = seg.GameObj.GetComponent<JointMotor>();
//
//        _rootSegment.AddChild(seg, new Vector3(1.3f, 0, 0));
//        
//
//        joint.joint.anchor = new Vector3(-0.5f, 0, 0);
//        joint.joint.enableCollision = true;
////        ((SpringJoint)joint.joint).maxDistance = 0;
////        ((SpringJoint)joint.joint).spring = 100;
//
//        //seg.GameObj.rigidbody.useGravity = false;
//        _rootSegment.GameObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
//        seg.GameObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
//
//        joint.joint.connectedBody = _rootSegment.GameObj.GetComponent<Rigidbody>();
//
//        BodySegment seg2 = new BodySegment();
//        _rootSegment.AddChild(seg2, new Vector3(-1.3f, 0, 0));
//        seg2.GameObj.AddComponent<SpringJoint>();
//        var joint2 = seg2.GameObj.GetComponent<JointMotor>();
//        joint2.joint.connectedBody = _rootSegment.GameObj.GetComponent<Rigidbody>();
//
//        BodySegment seg3 = new BodySegment();
//
//        seg3.GameObj.AddComponent<SpringJoint>();
//        var joint3 = seg3.GameObj.GetComponent<SpringJoint>();
//        seg.AddChild(seg3, new Vector3(1.3f, 0, 0));
//        joint3.connectedBody = seg2.GameObj.GetComponent<Rigidbody>();
//
//        Util.Parent(seg.GameObj, gameObject);
//        Util.Parent(seg2.GameObj, gameObject);
//        Util.Parent(seg3.GameObj, gameObject);	}
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
