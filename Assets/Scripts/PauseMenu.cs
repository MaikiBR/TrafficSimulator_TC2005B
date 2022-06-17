using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public int SCALE; 
    public GameUI gameUIMenu;
    public bool GameIsStarting = true;
    public bool starting = true; 

    void Start()
    {
        gameUIMenu = GameObject.FindObjectOfType<GameUI>();
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused && starting == false)
        {
            Pause();
        }
         else if(!GameIsPaused && starting == false)
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
        
        Time.timeScale = 1f;
        //StartCoroutine(LoadAsyncMenu());
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
        //Debug.Log("LoadingMenu..."); 
    }

    //IEnumerator LoadAsyncMenu()
    //{
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }
    //}

    public void FinishGame()
    {
        Time.timeScale = 0f ; 
    }
}
