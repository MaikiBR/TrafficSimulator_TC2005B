using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Cars
{
    Car,
    Moto,
    Bus,
    Truck
}

public class CarManager : MonoBehaviour
{
    private GameObject Vehicle;



    public bool isSpawn = false;
    public int spawnDelay;
    public int spawnTime;
    private string scene;

    //[ReadOnly]
    public Cars car = Cars.Car;
    void Update()
    {
        int ran = getRandomCar(); 
        if (!isSpawn)
        {
            if(ran == (int) Cars.Car)
            {
                isSpawn = true;
                Spawn("Car", spawnTime, spawnDelay);
            }

            else if(ran == (int) Cars.Moto)
            {
                isSpawn = true;
                Spawn("Car", spawnTime, spawnDelay);
            }

            else if (ran == (int) Cars.Truck)
            {
                isSpawn = true;
                Spawn("Car", spawnTime, spawnDelay);
            }

            else if (ran == (int) Cars.Bus)
            {
                isSpawn = true;
                Spawn("Car", spawnTime, spawnDelay);
            }
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
        }

    }

    void Spawn(string _vehicle, int _spawnTime, int _spawnDelay)
    {
        scene = SceneManager.GetActiveScene().name;

        switch (scene)
        {
            case "ROUTE1":
                break;

            case "ROUTE2":
                break;

            case "ROUTE3":
                break;

        }
    }

    void GetPath()
    {
        scene = SceneManager.GetActiveScene().name;
        GameObject paths = GameObject.Find("PATHS");
    }

    int getRandomCar()
    {
        return Random.RandomRange(0, 4);
    }
}
