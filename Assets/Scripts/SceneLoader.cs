using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;
    public float progress = 0;
    public GameObject music; 

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadScene_Coroutine(sceneName)); 
    }

    public IEnumerator LoadScene_Coroutine(string sceneName)
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        //float progress = 0;
        while (!asyncOperation.isDone)
        {
            Time.timeScale = 1f;
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;            
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                Debug.Log("Nel");
                asyncOperation.allowSceneActivation = true; 
            }
            yield return null; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            DontDestroyOnLoad(music);
        }

        else if (SceneManager.GetActiveScene().name != "RoadSelection")
        {
            Destroy(GameObject.Find("Music"));
        }
            
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //if(SceneManager.GetActiveScene().name != "Main" || SceneManager.GetActiveScene().name != "RoadSelection")
        //{
        //    Destroy(music);
        //}
    }
}
