using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{

    //private manager mgr;
    //private string vehicleTag;
    //public string state;

    //void Start()
    //{
    //    mgr = FindObjectOfType<manager>();
    //}

    //void OnTriggerEnter(Collider collision)
    //{
    //    vehicleTag = collision.gameObject.tag;
    //    AICar newCar;

    //    if (vehicleTag == "Car" || vehicleTag == "Moto" || vehicleTag == "Bus" || vehicleTag == "Truck")
    //    {
    //        if (collision is CapsuleCollider)
    //        {
    //            mgr.crash++;
    //            newCar = collision.gameObject.GetComponent<AICar>();
    //            gameObject.transform.parent.GetComponent<AICar>().state = "Green";
    //            newCar.state = "Green";
    //            Debug.Log("Aquí");
    //            //mgr.densidad--;
    //            gameObject.transform.parent.GetComponent<AICar>().destroy = true;
    //        }
    //    }

    //    if (vehicleTag == "Body")
    //    {
    //        newCar = collision.gameObject.transform.parent.GetComponent<AICar>();
    //        mgr.crash++;
    //        //gameObject.transform.parent.GetComponent<AICar>().state = "Green";
    //        newCar.state = "Green";
    //        Debug.Log("No");
    //        mgr.densidad--;
    //        gameObject.transform.parent.GetComponent<AICar>().destroy = true;
    //    }
    //}
}


