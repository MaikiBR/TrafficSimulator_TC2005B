using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILights : MonoBehaviour
{
    public List<Lights> lights;
    private List<string> state;
    public int greenLight; 
    public int time;
    public int num = 0; 
    Lights light; 
    // Start is called before the first frame update
    void Start()
    { 
        for(int i = 0; i < lights.Count; i++)
        {
            //light = lights[i]; 
            if(i == 0)
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

        InvokeRepeating("LightChange", 1, 3);
    }

    private void LightChange()
    {
        lights[greenLight].state = "Red"; 
        //state[greenLight] = "Red";
        if(greenLight <= lights.Count - 2)
        {
            greenLight++;
        }

        else
        {
            greenLight = 0;
        }
        //state[greenLight] = "Green";
        Invoke("Wait", 2.2f);
        
    }

    void Wait()
    {
        lights[greenLight].state = "Green"; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
