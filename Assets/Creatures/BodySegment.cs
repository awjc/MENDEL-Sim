using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Util;
using System.Linq;

/// <summary>
/// A single segment in a creatures body
/// </summary>
public class BodySegment
{
    public class SegmentConnection
    {
        public BodySegment connectedSegment;
        public Vector3 positionOnParent;
		public Vector3 positionOnChild;
		public JointMotor jointMotor;

		public SegmentConnection(BodySegment connectedSegment, Vector3 positionOnParent, Vector3 positionOnChild, JointMotor jointMotor)
        {
            this.connectedSegment = connectedSegment;
            this.positionOnParent = positionOnParent;
			this.positionOnChild = positionOnChild;
			this.jointMotor = jointMotor;
        }
    }
	public static GameObject JointConnectionPrefab;

    private List<SegmentConnection> _connections;

    private Color _color;

	private Vector3 _scale;

    public GameObject GameObj { get; private set; }

    private List<BodySegment> childList;
	public JointMotor myJointMotor{ get; set; }

	public List<Vector3> PosP = new List<Vector3>();
	public List<Vector3> PosC = new List<Vector3>();

    public JointBrainTree brain1;
    public JointBrainTree brain2;

    public BodySegment(JointBrainTree brain1, JointBrainTree brain2)
    {
		this.brain1 = brain1;
		this.brain2 = brain2;
        _connections = new List<SegmentConnection>();
        GameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObj.AddComponent<Rigidbody> ();
		GameObj.AddComponent<SegmentHolder> ();
		GameObj.GetComponent<SegmentHolder> ().segment = this;
    }

	public void update(double time)
	{
		if (myJointMotor != null) {
			float brainVal1 = (float) brain1.getTreeValue(time, this);
		//	Debug.Log ("[" + this.getName() + "] BRAIN1 --> " + brainVal1);
	        float brainVal2 = (float) brain2.getTreeValue(time, this);
		//	Debug.Log ("[" + this.getName() + "] BRAIN2 --> " + brainVal2);

			// left-right
			myJointMotor.ApplyTorque (new Vector3 (0, 1, 0), brainVal1);

			// up-down
			myJointMotor.ApplyTorque (new Vector3 (1, 0, 0), brainVal2);
		}

		foreach (var c in _connections) {
			c.connectedSegment.update(time);
		}
	}

    public List<BodySegment> getAllChildren()
    {
        if (childList == null)
        {
            childList = new List<BodySegment> { this };
            childList.AddRange(_connections.SelectMany(x => x.connectedSegment.getAllChildren()));
        }
        return childList;
    }

	public List<SegmentConnection> getConnections() {
		return _connections;
	}

	public Color getColor() {
		return _color;
	}

	public void setColor(Color color) {
		_color = color;
		GameObj.GetComponent<Renderer>().material.color = color;
	}

	public string getName() {
		return GameObj.name;
	}
	public void setName(string Name) {
		GameObj.name = Name;
	}

	public void setFab(GameObject fab)
	{
		JointConnectionPrefab = fab;
	}

	public Vector3 getScale() {
		return _scale;
	}
	public void setScale(Vector3 scale) {
		_scale = scale;
		GameObj.transform.localScale = scale;
	}

    public void AddChild(BodySegment child, Vector3 positionOnParent, Vector3 positionOnChild)
    {   
		PosP.Add (positionOnParent);
		PosC.Add (positionOnChild);

       // Util.ParentWithEmptyBetween(child.GameObj, this.GameObj);
        GameObject jcp = (GameObject)GameObject.Instantiate(JointConnectionPrefab, new Vector3(0, 0, 0), Quaternion.identity);

		jcp.transform.parent = this.GameObj.transform;

		jcp.transform.localPosition = positionOnParent;
		jcp.GetComponent<ConfigurableJoint> ().anchor = new Vector3 (0, 0, 0);
		jcp.transform.localScale = new Vector3 (1 / this.GameObj.transform.localScale.x,
		                                        1 / this.GameObj.transform.localScale.y,
		                                        1 / this.GameObj.transform.localScale.z);
		jcp.transform.localRotation = Quaternion.identity;
		jcp.GetComponent<ConfigurableJoint> ().autoConfigureConnectedAnchor = true;
		jcp.GetComponent<ConfigurableJoint> ().enableCollision = false;

		child.GameObj.transform.parent = jcp.transform;
		//child.GameObj.transform.localPosition = -positionOnChild;
		Vector3 ps = this.GameObj.transform.localScale;
		Vector3 v = new Vector3(positionOnParent.x * ps.x, positionOnParent.y * ps.y, positionOnParent.z * ps.z);
		Vector3 cs = child.GameObj.transform.localScale;
		Vector3 c = new Vector3(positionOnChild.x * cs.x, positionOnChild.y * cs.y, positionOnChild.z * cs.z);
		float d = 0.05f;
		child.GameObj.transform.localPosition = (c.magnitude + d) * (v.magnitude == 0 ? Vector3.zero : (v / v.magnitude));
		child.GameObj.transform.localRotation = Quaternion.FromToRotation (positionOnChild, jcp.transform.position - child.GameObj.transform.position);


		jcp.GetComponent<Rigidbody> ().useGravity = false;
	//	jcp.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
	//	child.GameObj.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
	//	this.GameObj.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		jcp.GetComponent<ConfigurableJoint>().connectedBody = child.GameObj.GetComponent<Rigidbody>();
		jcp.GetComponent<FixedJoint>().connectedBody = this.GameObj.GetComponent<Rigidbody>();
		var jointMotor = new JointMotor(jcp.GetComponent<ConfigurableJoint> (), 75);
		_connections.Add(new SegmentConnection(child, positionOnParent, positionOnChild, jointMotor));
		child.myJointMotor = jointMotor;
    }
}
