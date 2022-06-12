using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public int SCALE; 
    public GameUI gameUIMenu; 

    void Start()
    {
        gameUIMenu = GameObject.FindObjectOfType<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gameUIMenu.GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("LoadingMenu..."); 
    }

    public void FinishGame()
    {
        Debug.Log("QuittingGame..."); 
    }
}
