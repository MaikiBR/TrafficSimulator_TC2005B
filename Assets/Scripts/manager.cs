using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum Cars
//{
//    Car,
//    Moto,
//    Bus,
//    Truck
//}

public class manager : MonoBehaviour
{
    private GameObject Vehicle;
    public int densidad = 0;
    public int densidadMax = 0; 
    private string scene;
    public GameObject path;
    public List<GameObject> paths; 
    public List<AICar> vehicle;
    public List<Transform> startPosition; 
    public int length;
    private int startPoint = 0;
    public int carSpeed = 120;
    public int motoSpeed = 160;
    public int busSpeed = 90;
    public int truckSpeed = 70;
    private int carType; 

    //[ReadOnly]
    public Cars car = Cars.Car;

    void Start()
    {
        for(int i = 0; i < paths.Count; i++)
        {
            startPosition.Add(paths[i].transform.GetChild(0)); 
        }

        InvokeRepeating("Spawn", 1, 1);
    }

    void Update()
    {
        //InvokeRepeating("Spawn", 1, 0);
    }

    private void Spawn()
    {
        if(startPoint < paths.Count)
        {
            carType = Random.Range(0, 4);
            AICar vehicles = Instantiate(vehicle[carType], startPosition[startPoint].position, startPosition[startPoint].rotation);
            vehicles.Paths(paths[startPoint].transform);
            densidad++; 
            if(densidad >= densidadMax)
            {
                densidadMax = densidad; 
            }
            //Instantiate(vehicles, startPosition[startPoint].position, startPosition[startPoint].rotation);
            startPoint++; 
        }

        else
        {
            startPoint = 0; 
        }
    }

    public void updateScore()
    {
        densidad--; 
    }
    //void Update()
    //{

    //    if (!isSpawn)
    //    {
    //        int ran = getRandomCar();
    //        if (ran == (int)Cars.Car)
    //        {
    //            isSpawn = true;
    //            Spawn("Car", spawnTime, spawnDelay);
    //        }

    //        else if (ran == (int)Cars.Moto)
    //        {
    //            isSpawn = true;
    //            Spawn("Car", spawnTime, spawnDelay);
    //        }

    //        else if (ran == (int)Cars.Truck)
    //        {
    //            isSpawn = true;
    //            Spawn("Car", spawnTime, spawnDelay);
    //        }

    //        else if (ran == (int)Cars.Bus)
    //        {
    //            isSpawn = true;
    //            Spawn("Car", spawnTime, spawnDelay);
    //        }
            //switch (car)
            //{
            //    case Cars.Car:
            //        isSpawn = true; 
            //        Spawn("Car", spawnTime, spawnDelay);
            //        break; 

            //    case Cars.Moto:
            //        isSpawn = true;
            //        Spawn("Moto", spawnTime, spawnDelay);
            //        break;

            //    case Cars.Bus:
            //        isSpawn = true;
            //        Spawn("Bus", spawnTime, spawnDelay);
            //        break;

            //    case Cars.Truck:
            //        isSpawn = true;
            //        Spawn("Truck", spawnTime, spawnDelay);
            //        break;

            //}
    //    }

    //}

    //void Spawn(string _vehicle, int _spawnTime, int _spawnDelay)
    //{
    //    scene = SceneManager.GetActiveScene().name;

    //    switch (scene)
    //    {
    //        case "ROUTE1":
    //            break;

    //        case "ROUTE2":
    //            break;

    //        case "ROUTE3":
    //            break;

    //    }
    //}

    //void GetPath()
    //{
    //    scene = SceneManager.GetActiveScene().name;
    //    GameObject paths = GameObject.Find("PATHS");
    //}

    //int getRandomCar()
    //{
    //    return Random.RandomRange(0, 4);
    //}
}
