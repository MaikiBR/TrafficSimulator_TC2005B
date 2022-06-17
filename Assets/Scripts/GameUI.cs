using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    public bool GameIsPaused = false;
    private PauseMenu pauseMenu;
    public GameObject gameUI;
    private manager mgr;
    public SummaryScript summary; 
    private bool starting = true; 
    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = true;
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        mgr = FindObjectOfType<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameIsPaused)
        //{
        //    gameUI.SetActive(false);
        //}

        //else
        //{
        //    gameUI.SetActive(true);
        //}
    }

    public void Pause()
    {
        pauseMenu.GameIsPaused = true;
        GameIsPaused = true;
        //gameUI.SetActive(false);
    }

    public void Play()
    {
        Time.timeScale = 1f; 
        //pauseMenu.Resume();
        pauseMenu.starting = false; 
    }

    public void Finish()
    {
        GameIsPaused = true;
        summary.Show();
        pauseMenu.FinishGame(); 
    }

    void Starting()
    {

    }
}

