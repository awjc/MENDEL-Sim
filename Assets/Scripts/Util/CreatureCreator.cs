using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class CreatureCreator : MonoBehaviour {


	//    public static GameObject Load(string path){
//        GameObject creature = new GameObject ();
//        BodySegment root;
//        int segCount = 0;
//        using (XmlReader reader = XmlReader.Create(path)) {
//            string state = "";
//            while(reader.Read)
//            {
//                if(reader.IsStartElement){
//                    switch(reader.Name)
//                    {
//                    case "Name":
//                        creature.name = reader.Value;
//                        break;
//                    case "Child":
//                        //TODO
//                        BodySegment s = loadSegment(reader);
//                        Joint j = loadJoint(reader);
//                        root.AddChild(s, new Vector3(0, 0, 0), j);
//                        break;	
//                    case "Segment":
//                        root = loadSegment(reader);
//                        break;
//                    default:
//                        break;
//                    }
//                }
//            }
//        }

//        return creature;
//    }

//    public static BodySegment loadSegment(XmlReader reader, BodySegment parent)
//    {
//        BodySegment seg = new BodySegment ();
//        //while(reader.Read)
//        // when you  hit <Segment>, increase segCount
//        // when you hit </Segment>, decrease segCount
//        // when segCount hits 0, break out of loop
//        while(reader.Read)
//        {
//            if(reader.IsStartElement)
//            {
//                switch(reader.Name)
//                {
//                case "Color":
//                    string value = reader.Value;
//                    string[] parts = value.Split(",");
//                    float r = float.Parse(parts[0]);
//                    float g = float.Parse(parts[1]);
//                    float b = float.Parse(parts[2]);
//                    float a = float.Parse(parts[3]);
//                    Color c = new Color(r, g, b, a);
//                    seg.setColor(c);
//                    break;
//                case "Scale":
//                    string value1 = reader.Value;
//                    string[] parts1 = value.Split(",");
//                    float x = float.Parse(parts[0]);
//                    float y = float.Parse(parts[1]);
//                    float z = float.Parse(parts[2]);
//                    Vector3 v = new Vector3(x, y, z);
//                    seg.setScale(v);
//                    break;
//                case "Child":
//                    seg.AddChild(loadSegment(reader, seg), new Vector3(0, 0, 0));//TODO
//                    break;
//                case "Segment":
//                    segCount++;
////					BodySegment root = loadSegment(reader);
//                    break;
//                default:
//                    break;
//                }
//            }
			
//        }
//        return seg;
//    }

//    public static Joint loadJoint(XmlReader reader)
//    {
//        //TODO
//    }

//    public static void WriteSegment(XmlWriter writer, BodySegment b){
//        writer.WriteStartElement("Segment");
//        writer.WriteElementString ("Name", b.getName());
//        writer.WriteElementString("Color", b.getColor().r.ToString("R") + "," + b.getColor().g.ToString("R") + "," + b.getColor().b.ToString("R") + "," + b.getColor().a.ToString("R"));
//        writer.WriteElementString ("Scale", b.getScale().x.ToString ("R") + "," + b.getScale ().y.ToString("R") + "," + b.getScale().z.ToString("R"));
//        writer.WriteStartElement("Children");
//        foreach( var connection in b.getConnections() )
//        {
//            writer.WriteStartElement("Child");
//            writer.WriteStartElement("Segment");
		
//            WriteSegment(writer, connection.connectedSegment);
			
//            writer.WriteEndElement();
			
//            WriteJoint(writer, connection.joint);
			
//            writer.WriteEndElement();
//        }

//        writer.WriteEndElement();
//        writer.WriteEndElement();
//    }

//    public static void WriteJoint(XmlWriter writer, JointMotor j){
//        writer.WriteStartElement ("Joint");
//        writer.WriteElementString ("strength", j.strength.ToString());
//        writer.WriteElementString ("break_force", j.joint.breakForce.ToString());
//        writer.WriteElementString ("break_torque", j.joint.breakTorque.ToString());
//        writer.WriteEndElement();
//    }

//    public static void Save(string path, Creature c){
//        using (XmlWriter writer = XmlWriter.Create(path))
//        {
//            writer.WriteStartDocument();
//            writer.WriteStartElement("Creature");

//            writer.WriteElementString("Name", c.Name);

//            WriteSegment(writer, c._rootSegment);

//            writer.WriteEndElement();
//            writer.WriteEndDocument();
//        };

//    }
	// Use this for initialization
	void Start () {
		//createRandomCreature ();
	}

	
	// Update is called once per frame
	void Update () {
		/*if(needToSaveCreature)
		 * {
		 *  
		 * }
		 * 
		 * 
		 * 
		 * 
		 *
		 */
	}
}
