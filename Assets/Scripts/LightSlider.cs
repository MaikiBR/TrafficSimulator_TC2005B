using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSlider : MonoBehaviour
{
    public UnityEngine.UI.Slider _slider;
    public Text _sliderText;
    private AILights light;
    private GameObject[] lights; 
    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Lights");
        _slider.onValueChanged.AddListener(delegate { assignLightTime(); });
    }

    private void assignLightTime()
    {
        foreach (GameObject lgt in lights)
        {
            lgt.GetComponent<AILights>().lightTime = (int) _slider.value; 
        }
        _sliderText.text = "LIGHT TIME: " + _slider.value + " SEC";
    }
}
