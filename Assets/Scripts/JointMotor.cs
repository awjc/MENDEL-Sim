using UnityEngine;
using System.Collections;
using System.Linq;

public class JointMotor{

	public float strength { get; set; }
	public ConfigurableJoint joint { get; set; }

	public JointMotor(ConfigurableJoint joint, float strength)
	{
		this.joint = joint;
		this.strength = strength;
	}

	public void ApplyTorque(Vector3 direction, float scale)
	{
		joint.connectedBody.AddRelativeTorque (direction * strength * scale, ForceMode.Force);
	}
}
