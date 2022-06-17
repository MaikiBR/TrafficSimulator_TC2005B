using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private AICar newCar;
    private AICar oldCar;
    public string state;
    private string oldState; 
    public Light lt; 
    private string carTag;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        oldState = state; 
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
            if(collision is BoxCollider)
            {
                newCar.state = state; 
            }

            else
            {
                newCar.state = state;
            }
            
        }
    }

    void Update()
    {
        if (newCar != null && state == "Green")
        {
            Debug.Log("Green");
            newCar.state = state;
        }

            lightColor();
        
    }

    private void lightColor()
    {
        switch (state)
        {
            case "Green":
                lt.color = Color.green;
                break;
            case "Red":
                lt.color = Color.red;
                break;
            case "Yellow":
                lt.color = Color.yellow;
                break;
        }
    }

    // Update is called once per frame
}
