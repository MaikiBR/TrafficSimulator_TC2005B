using System.Collections;
using UnityEngine;
using System.Collections.Generic; 

public class AICar : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public float maxMotorTorque = 15f;
    public float currentSpeed;
    public float maxSpeed = 100;
    public float maxBrakeTorque = 10f; 
    private int currentNode = 0;
    public bool isBraking = false; 
    private List<Transform> nodes; 
    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
    }
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        leftWheel.steerAngle = newSteer;
        rightWheel.steerAngle = newSteer; 
    }

    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * leftWheel.radius * leftWheel.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed && !isBraking)
        {
            leftWheel.motorTorque = maxMotorTorque;
            rightWheel.motorTorque = maxMotorTorque;
        }

        else
        {
           leftWheel.motorTorque = 0;
           rightWheel.motorTorque = 0;
        }

    }

    private void CheckWaypointDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode].position) < 0.05f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0; 
            }
            else
            {
                currentNode++; 
            }
        }
    }

    private void Braking()
    {
        if (isBraking)
        {
            leftWheel.brakeTorque = maxBrakeTorque;
            rightWheel.brakeTorque = maxBrakeTorque; 
        }
        else
        {
            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
        }
    }
}
