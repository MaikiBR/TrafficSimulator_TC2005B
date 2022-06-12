using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private AICar newCar;
    private AICar oldCar; 
    public string state;
    private string carTag;
    public int id; 
    // Start is called before the first frame update
    void Start()
    {
        state = "Red"; 
    }

    public void setState(string _state)
    {
        state = _state; 
    }

    public string getState()
    {
        return state; 
    }

    void OnTriggerEnter(Collider collision)
    {
        carTag = collision.gameObject.tag;
        if (carTag == "Car" || carTag == "Bus" || carTag == "Truck" || carTag == "Moto")
        {
            newCar = collision.gameObject.GetComponent<AICar>();
            newCar.state = state;
        }
    }

    void Update()
    {
        if(newCar != null && state == "Green")
        {
            newCar.state = state;
        }
    }

    // Update is called once per frame
}
