using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar2 : MonoBehaviour
{
    public Transform paths; 
    public Transform path;
    private List<Transform> _path; 
    private Rigidbody rb;
    private List<Transform> nodes;
    public int currentNode = 0;



    void Start()
    {
        paths = GameObject.Find("PATHS").transform;

        rb = GetComponent<Rigidbody>();
        path = paths.transform.GetChild(Random.Range(0, paths.transform.childCount - 1));
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