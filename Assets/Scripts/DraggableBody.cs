using UnityEngine;
using System.Collections;

public class DraggableBody : MonoBehaviour
{
    public float P = 20F;
    public float I = 0.5F;
    public float D = 10F;

    private bool dragging = false;
    private Plane plane;
    private Vector3 prev;
    private Vector3 cum;


    // Use this for initialization
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.X))
        {
            dragging = true;
            plane = new Plane(-Camera.main.transform.forward, gameObject.transform.position);
			cum = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            dragging = false;
            return;
        }

        if (dragging)
        {
            //float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
            //float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter;
            if (plane.Raycast(ray, out enter))
            {
                Vector3 err = (ray.origin + ray.direction * enter) - gameObject.transform.position;

                // PID controller
                Vector3 pComp = P * err;
                Vector3 dComp = D * (err - prev) / Time.deltaTime;
                cum += err;
                Vector3 iComp = I * cum;

                var sum = pComp + dComp + iComp;

               // Debug.Log("Err: " + err + " ::: P: " + pComp + " ::: I: " + iComp + " ::: D: " + dComp + " ::: Sum: " + sum);

                prev = err;

                //Vector3 planeCoord = Quaternion.Inverse(Camera.main.transform.rotation) * sum;
                //Debug.Log(planeCoord);
                //planeCoord.z = 0;
                //sum = Camera.main.transform.rotation * planeCoord;
                //Debug.Log("SUM: " + sum);

                gameObject.GetComponent<Rigidbody>().AddForce(sum, ForceMode.Acceleration);

                float scroll = Input.GetAxis("Mouse ScrollWheel");
                //plane = new Plane(plane.normal, plane.distance - 10 * scroll);
                plane.distance += 10 * scroll;
            //    gameObject.rigidbody.AddForce(100 * Camera.main.transform.forward * scroll, ForceMode.Acceleration);
              //  Debug.Log(scroll);
            }
           // Vector3 v = ShortestVectorToRay(gameObject.transform.position, ray);
       

           
        }
    }

    public static Vector3 ShortestVectorToRay(Vector3 point, Ray ray)
    {
        Vector3 intersectionPoint = ray.origin + ray.direction * Vector3.Dot(ray.direction, point - ray.origin);
        return intersectionPoint - point; 
    }
}
