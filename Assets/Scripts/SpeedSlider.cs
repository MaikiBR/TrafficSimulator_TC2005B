using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    public UnityEngine.UI.Slider _slider;
    public Text _sliderText;
    private manager mgr;
    public int carType;
    private int speed; 
    // Start is called before the first frame update
    void Start()
    {
        mgr = FindObjectOfType<manager>();
        _slider.onValueChanged.AddListener(delegate { assignSpeed(); });
    }

    private void assignSpeed()
    {
        mgr.setSpeed(carType, (int)_slider.value); 
        _sliderText.text = "SPEED: " + _slider.value + " KM/H";
    }
}
