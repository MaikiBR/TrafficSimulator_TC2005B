using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    // Start is called before the first frame update 
    
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene("ROAD1");
    }

    public void LoadMenu()
    {

    }

    public void FinishGame()
    {

    }
}
