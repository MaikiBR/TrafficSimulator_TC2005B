using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class Simulation
{
    public int roadType;
    public List<int> carToSpawn;
    public int lightLength;
    public int densidad;
    public int porcentaje; 
}

public class SummaryScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GameIsPaused = false;
    public GameObject summary;
    public int SCALE;
    public GameUI gameUIMenu;
    public bool GameIsStarting = true;
    public bool starting = true;
    private bool exit = false;
    public Text _currentDensity;
    public Text _maxDensity;
    public Text _completedPaths;
    private manager mgr;
    private AILights _lights; 
    private int userId;
    public int roadType;
    private List<int> carToSpawn;
    private int lightLength;
    private int densidad;
    private int porcentaje;
    private SceneLoader scene;


    void Start()
    {
        summary.SetActive(false); 
        mgr = FindObjectOfType<manager>();
        scene = FindObjectOfType<SceneLoader>(); 
        _lights = FindObjectOfType<AILights>();
    }

    void Update()
    {
        if (exit)
        {
            Time.timeScale = 0f; 
        }
    }

    // Update is called once per frame

    public void Save()
    {
        //Time.timeScale = 0f;
        //API
        //authChexi = new Auth();
        carToSpawn = mgr.spawnIndex;
        lightLength = _lights.lightTime;
        densidad = mgr.densidadMax;
        try
        {
            porcentaje = mgr.totalCars * 100 / mgr.spawnCars;
        }

        catch
        {
            porcentaje = 0;
        }
        
        StartCoroutine(PostSimulation(roadType, carToSpawn, lightLength, densidad, porcentaje));
        //PostData(); 
    }

    void Continue()
    {
        //pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Show()
    {
        
        summary.SetActive(true);
        _currentDensity.text = "CURRENT DENSITY:    " + mgr.densidad;
        _maxDensity.text = "MAXIMUM DENSITY:  " + mgr.densidadMax;
        _completedPaths.text = "COMPLETED PATHS:    " + mgr.totalCars * 100 / mgr.spawnCars;
        exit = true; 
        //Time.timeScale = 0f;
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
        Debug.Log("QuittingGame...");
    }

    public IEnumerator PostSimulation(int _roadType, List<int> _carToSpawn, int _lightLength, int _densidad, int _porcentaje)
    {
        //@TODO: call API login
        // Store Token
        // Add Token to headers

        var simulation = new Simulation();

        simulation.roadType = _roadType;
        simulation.carToSpawn = _carToSpawn;
        simulation.lightLength = _lightLength;
        simulation.densidad = _densidad;
        simulation.porcentaje = _porcentaje;


        string json = JsonUtility.ToJson(simulation);

        var req = new UnityWebRequest("http://eq4.appworld.com.mx/api/simulation", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            Debug.Log("Received: " + req.downloadHandler.text);
        }

        scene.LoadScene("Main"); 
    }

    //public void PostData()
    //{
    //    StartCoroutine(PostDataCorrutina());
    //}
    //IEnumerator PostDataCorrutina()
    //{
    //    string url = "http://eq4.appworld.com.mx/api/simulation";
    //    WWWForm form = new WWWForm();
    //    form = formPost(form);
    //    //form.AddField("title", "dataTest");
    //    using (UnityWebRequest request = UnityWebRequest.Post(url, form))
    //    {
    //        yield return request.SendWebRequest();
    //        if (request.isNetworkError || request.isHttpError)
    //        {
    //            Debug.LogError(request.error);
    //        }
    //        else
    //        {
    //            Debug.Log(request.downloadHandler.text);
    //        }
    //    }
    //}

    //WWWForm formPost(WWWForm _form)
    //{
    //    _form.AddField("Id", "78912");
    //    _form.AddField("Customer", "Jason Sweet");
    //    _form.AddField("Quantity", 1);
    //    _form.AddField("Price", 18);

    //    return _form;
    //}
}
