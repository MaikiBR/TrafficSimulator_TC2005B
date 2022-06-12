using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    public bool GameIsPaused = false;
    private PauseMenu pauseMenu;
    public GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            gameUI.SetActive(false);
        }

        else
        {
            gameUI.SetActive(true);
        }
    }

    public void Pause()
    {
        pauseMenu.GameIsPaused = true;
        GameIsPaused = true;
        gameUI.SetActive(false);
    }
}

