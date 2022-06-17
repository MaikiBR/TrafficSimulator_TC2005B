using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public Toggle isSpawning;
    private manager mgr;
    public int carType;

    private void Start()
    {
        mgr = FindObjectOfType<manager>();
        isSpawning.onValueChanged.AddListener(delegate { spawnCar(); });
    }

    private void spawnCar()
    {
        if (isSpawning.isOn)
        {
            mgr.addSpawningCar(carType);
        }

        else if (!isSpawning.isOn)
        {
            mgr.removeSpawningCar(carType);
        }
    }

}