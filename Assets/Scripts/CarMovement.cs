//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CarMovement : MonoBehaviour
//{
//    public Transform path;
//    private Rigidbody rb;
//    private List<Transform> nodes;
//    public int currentNode = 0;
//    public int velocity = 160;
//    public string state = "Green";
//    public Lights light;
//    private string vehicleTag;
//    private manager mgr;
//    private GameObject Mgr;
//    private float carSpeed;
//    private string slow = "No";
//    private NavMeshAgent _carNavmesh;
//    public float safeDistance = 2f; 

//    public void Paths(Transform _path)
//    {
//        path = _path;
//        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
//        nodes = new List<Transform>();
//        for (int i = 0; i < pathTransforms.Length; i++)
//        {
//            if (pathTransforms[i] != path.transform)
//            {
//                nodes.Add(pathTransforms[i]);
//            }
//        }
//        currentNode = 0;
//    }

//    void Start()
//    {
//        carSpeed = (float)velocity * 0.7f / 160f;
//        _carNavmesh = this.gameObject.GetComponent<NavMeshAgent>();
//        _carNavmesh.speed = carSpeed; 
//        mgr = FindObjectOfType<manager>();
//        //rb = GetComponent<Rigidbody>();
//        //assignSpeed();
//    }

//    private void Update()
//    {
//        RaycastHit hit;
//        Physics.Raycast(transform.position, transform.forward, out hit, safeDistance); 
        
//        if(hit.transform.tag == "Car" || hit.transform.tag == "Bus" || hit.transform.tag == "Moto" || hit.transform.tag == "Truck")
//        {
//            Stop(); 
//        }

//        else
//        {
//            Move(); 
//        }

//    }

//    void Stop()
//    {
//        _carNavmesh.speed = 0; 
//    }

//    private void assignSpeed()
//    {
//        if (gameObject.tag == "Bus")
//        {
//            speed = mgr.busSpeed;
//        }

//        else if (gameObject.tag == "Moto")
//        {
//            carSpeed = mgr.motoSpeed;
//        }

//        else if (gameObject.tag == "Truck")
//        {
//            carSpeed = mgr.truckSpeed;
//        }

//        else
//        {
//            carSpeed = mgr.carSpeed;
//        }
//    }

//    void FixedUpdate()
//    {

//        assignSpeed();

//        velocity = (float)carSpeed * 0.7f / 160f;
//        if (state == "Red")
//        {
//            rb.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, 0 * Time.deltaTime);
//        }


//        //rb.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, 0.0f * Time.deltaTime);

//        else
//        {
//            rb.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, velocity * Time.deltaTime);
//            float degreesPerSecond = 90 * Time.deltaTime;
//            Vector3 direction = nodes[currentNode].transform.position - transform.position;
//            Quaternion targetRotation = Quaternion.LookRotation(direction);
//            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
//        }

//        CheckWaypointDistance();
//    }

//    private void CheckWaypointDistance()
//    {
//        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.05f)
//        {
//            if (currentNode == nodes.Count - 1)
//            {
//                mgr.updateScore();
//                Destroy(gameObject);
//            }
//            else
//            {
//                currentNode++;
//            }
//        }
//    }

//    public void setPath(Transform _path)
//    {
//        path = _path;
//        currentNode = 0;
//    }

//    void OnTriggerEnter(Collider collision)
//    {
//        vehicleTag = collision.gameObject.tag;
//        if (vehicleTag == "Car" || vehicleTag == "Moto" || vehicleTag == "Bus" || vehicleTag == "Truck")
//        {
//            if (collision is MeshCollider)
//            {
//                carSpeed = 0;
//            }

//            else if (collision is BoxCollider)
//            {
//                state = "Red";
//            }
//            //Debug.Log("DETECTA CARRO"); 
//        }

//        else if (vehicleTag == "Light")
//        {
//            Lights newLight = collision.gameObject.GetComponent<Lights>();
//            state = newLight.state;
//        }
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        vehicleTag = collision.gameObject.tag;
//        if (vehicleTag == "Car" || vehicleTag == "Moto" || vehicleTag == "Bus" || vehicleTag == "Truck" && collision is MeshCollider)
//        {
//            Destroy(gameObject);
//            mgr.crash++;



//            Debug.Log("CHOQUE");
//        }
//    }

//    void OnTriggerExit(Collider collision)
//    {
//        state = "Green";
//        assignSpeed();
//    }

//}
//}
