using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILights : MonoBehaviour
{
    public List<Lights> lights;
    private List<string> state;
    public int greenLight;
    private int previousGreenLight; 
    public int time;
    public int num = 0;
    public int previousLightTime;
    public int lightTime = 3; 
    Lights light;
    private bool change = false; 
    // Start is called before the first frame update
    void Start()
    {
        lightTime = 3;
        for (int i = 0; i < lights.Count; i++)
        {
            //light = lights[i]; 
            if (i == 0)
            {
                lights[0].state = "Green";
                //state[0] = "Green"; 
            }
            else
            {
                lights[i].state = "Red";
                //state[i] = "Red"; 
            }
            num++;
        }

        previousLightTime = lightTime; 
        InvokeRepeating("LightChange", 1, lightTime + 2);
        change = true; 
    }

    private void LightChange()
    {
        lights[greenLight].state = "Yellow";
        //state[greenLight] = "Red";
        if (greenLight <= lights.Count - 2)
        {
            previousGreenLight = greenLight; 
            greenLight++;
        }

        else
        {
            previousGreenLight = greenLight;
            greenLight = 0;
        }
        //lights[greenLight].state = "Green";
        StartCoroutine(Waiting());

    }

    void Wait()
    {
        lights[greenLight].state = "Green";
    }
    // Update is called once per frame
    void Update()
    {
        if (previousLightTime != lightTime)
        {
            change = false;
            CancelInvoke("LightChange");
            Spawnee();
        }
    }

    IEnumerator Waiting()
    {
        
        yield return new WaitForSeconds(2);
        lights[previousGreenLight].state = "Red";
        lights[greenLight].state = "Green";

    }

    void Spawnee()
    {
        previousLightTime = lightTime;
        InvokeRepeating("LightChange", 1, lightTime + 2);
        change = true;
    }
}
