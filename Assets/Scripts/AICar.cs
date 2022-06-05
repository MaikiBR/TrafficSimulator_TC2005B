using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public Transform path;
    private Rigidbody rb;
    private List<Transform> nodes;
    public int currentNode = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //m_EulerAngleVelocity = new Vector3(0, 100, 0); 
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
        transform.LookAt(nodes[currentNode].position);
    }

        void FixedUpdate()
        {
        rb.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, 0.4f * Time.deltaTime);
        float degreesPerSecond = 90 * Time.deltaTime;
        Vector3 direction = nodes[currentNode].transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
        CheckWaypointDistance();
        }
    //Quaternion targetRotation = Quaternion.LookRotation(direction);
    //rb.MovePosition(transform.position + nodes[currentNode].transform.position * Time.deltaTime * 0.2f);
    
        private void CheckWaypointDistance()
        {
            if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.05f)
            {
                if (currentNode == nodes.Count - 1)
                {
                    currentNode = 0;
                }
                else
                {
                    currentNode++;
                }
            }
        }

    public void setPath(Transform _path)
    {
        path = _path; 
    }

}


//public float force = 5;
//    public Rigidbody rb;
//    public float turn_speed = 2f;
//    public float dis_changewaypoint = 10f;
//    private Vector3 current_waypoint;
//    //private List<Vector3> waypoints = new List<Vector3>();
//    public int currentNode = 0;
//    private float rotationSpeed = 45f;
//    private float speed = 50f; 
//    public Transform path;
//    Vector3 angVel = new Vector3(0, 100, 0);

//    private List<Transform> nodes;
//    Vector3 relativeVector; 


//    private float start_game = 0;


//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        Vector3 relativePos = nodes[currentNode].position - transform.position;
//        Face_node(relativePos); 

//        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
//        nodes = new List<Transform>();
//        for (int i = 0; i < pathTransforms.Length; i++)
//        {
//            if (pathTransforms[i] != path.transform)
//            {
//                nodes.Add(pathTransforms[i]);
//            }
//        }

//    }



//    void FixedUpdate()
//    {

//        CheckWaypointDistance();
//        Vector3 relativePos = nodes[currentNode].position - transform.position;
//        Face_node(relativePos); //rotates object to face waypoint
//        Moveobject();


//        //if (currentNode >= nodes.Count) return;

//        //Vector3 deltaPos = nodes[currentNode].transform.position - transform.position;
//        //rb.velocity = 1f / Time.fixedDeltaTime * deltaPos * Mathf.Pow(0.2f, 90f * Time.fixedDeltaTime);

//        //Quaternion deltaRot = nodes[currentNode].transform.rotation * Quaternion.Inverse(transform.rotation);

//        //float angle;
//        //Vector3 axis;

//        //deltaRot.ToAngleAxis(out angle, out axis);

//        //if (angle > 180.0f) angle -= 360.0f;

//        //if (angle != 0) rb.angularVelocity = (1f / Time.fixedDeltaTime * angle * axis * 0.01745329251994f * Mathf.Pow(1f, 90f * Time.fixedDeltaTime));

//    }

//    void Moveobject()
//    {
//        if (Mathf.Abs(force) > Mathf.Abs(rb.velocity.z + rb.velocity.x))
//        {
//            rb.AddForce(transform.forward * force);
//        }
//    }

//    void Face_node(Vector3 relativePos)
//    {

//        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
//        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turn_speed);  // slerp ( from.rotation, to.rotation, speed)
//    }


//    private void CheckWaypointDistance()
//    {
//        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.01f)
//        {
//            if (currentNode == nodes.Count - 1)
//            {
//                currentNode = 0;
//            }
//            else
//            {
//                currentNode++;
//            }
//        }
//    }

