using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DensityScript : MonoBehaviour
{
    
    public Text _densityText;
    private manager mgr; 
    // Start is called before the first frame update
    void Start()
    {
        mgr = FindObjectOfType<manager>();
    }

    void Update()
    {
        _densityText.text = "DENSITY: " + mgr.densidad; 
    }
}