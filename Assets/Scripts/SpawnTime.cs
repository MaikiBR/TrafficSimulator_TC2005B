using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTime : MonoBehaviour
{
    public UnityEngine.UI.Slider _slider;
    public Text _sliderText;
    private manager mgr;
    // Start is called before the first frame update
    void Start()
    {
        mgr = FindObjectOfType<manager>();
        _slider.onValueChanged.AddListener(delegate { assignSpawnTime(); });
    }

    private void assignSpawnTime()
    {
        mgr.spawnTime = _slider.value;
        _sliderText.text = "SPAWNING TIME: " + _slider.value + " SEC";
    }
}

