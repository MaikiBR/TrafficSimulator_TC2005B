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
    public int spawnCars = 0;
    public int totalCars = 0; 
    private string scene;
    public GameObject path;
    public List<GameObject> paths; 
    public List<AICar> vehicle;
    public List<Transform> startPosition;
    public List<AICar> spawningVehicles;
    public List<int> spawnIndex = new List<int> { 0, 1, 2, 3 };
    //public int[] spawnIndex = { 0, 1, 2, 3 }; 
    public List<int> speeds; 
    public int length;
    private int startPoint = 0;
    public int carSpeed = 120;
    public int motoSpeed = 160;
    public int busSpeed = 90;
    public int truckSpeed = 70;
    private int carType;
    public int crash = 0;
    public float spawnTime = 3f;
    public float previousSpawmTime; 
    private int speed;
    private bool spawn = false; 

    //[ReadOnly]
    public Cars car = Cars.Car;

    void Start()
    {
        for(int i = 0; i < paths.Count; i++)
        {
            startPosition.Add(paths[i].transform.GetChild(0)); 
        }
        previousSpawmTime = spawnTime;
        InvokeRepeating("Spawn", 1, spawnTime/2);
        spawn = true; 
    }

    void Update()
    {
        if(previousSpawmTime != spawnTime)
        {
            spawn = false; 
            CancelInvoke("Spawn");
            Spawnee(); 
        } 

        if(densidad >= densidadMax)
        {
            densidadMax = densidad; 
        }
    }

    void Spawnee()
    {
        previousSpawmTime = spawnTime;
        InvokeRepeating("Spawn", 1, spawnTime/2);
        spawn = true;
    }

    private void Spawn()
    {
        if(startPoint < paths.Count)
        {
            try
            {
                carType = spawnIndex[Random.Range(0, spawnIndex.Count)];
                assignSpeed(); 
                Debug.Log(startPosition[startPoint].rotation);
                AICar vehicles = Instantiate(vehicle[carType], startPosition[startPoint].position, startPosition[startPoint].rotation);
                vehicles.speed = speed; 
                vehicles.Paths(paths[startPoint].transform);
                densidad++;
                spawnCars++;
                if(densidad >= densidadMax)
                {
                    densidadMax = densidad; 
                }
                //Instantiate(vehicles, startPosition[startPoint].position, startPosition[startPoint].rotation);
                startPoint++; 
            }
            catch
            {

            }
            
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

    void assignSpeed()
    {
        switch (carType)
        {
            case 0:
                speed =  busSpeed;
                break;
            case 1:
                speed = motoSpeed;
                break;
            case 2:
                speed = truckSpeed;
                break;
            case 3:
                speed = carSpeed;
                break; 

        }
    }

    public void setSpeed(int _carType, int _speed)
    {
        switch (_carType)
        {
            case 0:
                busSpeed = _speed;
                break;
            case 1:
                motoSpeed = _speed;
                break;
            case 2:
                truckSpeed = _speed; 
                break;
            case 3:
                carSpeed = _speed;
                break;

        }
    }

    public void addSpawningCar(int _carType)
    {
        spawnIndex.Add(_carType);
    }

    public void removeSpawningCar(int _carType)
    {
        spawnIndex.Remove(_carType);
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
