using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 

public class POST : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData); 
    }
    void PostData() => StartCoroutine(PostData_Coroutine()); 

    IEnumerator PostData_Coroutine()
    {
        string url = "https://my-json-server.typicode.com/typicode/demo/posts";
        WWWForm form = new WWWForm();
        form.AddField("title", "Simulador");
        //form = simulationForm(form);
        using(UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    WWWForm simulationForm(WWWForm _form)
    {

        _form.AddField("title", "Simulador");
        //_form.AddField("user_id", 105);
        //_form.AddField("title", "Traffic Simulator");
        //_form.AddField("body", "Un simulador de tráfico vial");
        return _form;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
