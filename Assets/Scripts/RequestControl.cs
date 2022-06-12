using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class RequestControl : MonoBehaviour
{
    private const string url = "https://jsonplaceholder.typicode.com/todos/1";

    // Start is called before the first frame update
    void Start()
    {

    }

    public async void GetData()
    {
        var www = UnityWebRequest.Get(url);
        var op = www.SendWebRequest();

        while (!op.isDone)
        {
            await Task.Yield();
            if (www.result == UnityWebRequest.Result.Success)
            {
                //var N = JSON.Parse(r.downloadHandler.text);

                //var theJsonArray = N["Search"].Values;

                //Debug.Log(www.downloadHandler.text);
                //assignValues(theJsonArray); 
                Debug.Log(www.downloadHandler.text);
            }
            //else
            //{
            //    Debug.LogError(www.error);
            //} 
        }
    }

    //private void assignValues(var _Array)
    //{
    //    foreach (var item in theJsonArray)
    //    {
    //        var movieInfo = new MovieSearchInfo();
    //        movieInfo.Title = item["title"];
    //        movieInfo.Year = item["Year"];
    //        movieInfo.imdbID = item["imdbID"];
    //        movieInfo.Type = item["Type"];

    //        // NOW DO SOMETHING WITH IT

    //        // wait for the next frame to continue
    //        yield return null;
    //    }
    //}

    public void PostData()
    {
        StartCoroutine(PostDataCorrutina());
    }
    IEnumerator PostDataCorrutina()
    {
        string url = "https://reqbin.com/echo/post/json";
        WWWForm form = new WWWForm();
        form = formPost(form); 
        //form.AddField("title", "dataTest");
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
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

    WWWForm formPost(WWWForm _form)
    {
        _form.AddField("Id", "78912");
        _form.AddField("Customer", "Jason Sweet");
        _form.AddField("Quantity", 1);
        _form.AddField("Price", 18);

        return _form; 
    }

}