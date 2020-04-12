using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DiamondScript : MonoBehaviour
{

	
	// private string jsonURL = "http://127.0.0.1:8000/game/get_ready_to_player_players/1/";

	private string jsonURL = "http://leatonm.net//CandlepinData/jsonfile.json";

	private string postUrl = "http://127.0.0.1:8000/game/signup/";

    void Start()
    {
    	// StartCoroutine(getData());
    	StartCoroutine(postData());
    }

    // --------------------------**GET**---------------------------

    IEnumerator getData() {
    	Debug.Log("Processing Data..");

    	/*
    	WWW _www = new WWW(jsonURL);
    	yield return _www;

    	if (_www.error == null) {
    		processJsonData(_www.text);
    	} else {
    		Debug.Log("Networking Dikkat hai");
    	}
    	*/

    	UnityWebRequest www = UnityWebRequest.Get(jsonURL);
    	yield return www.SendWebRequest();

    	if (www.isNetworkError || www.isHttpError) {
    		Debug.LogError("Networking Dikkat hai");
    		Debug.LogError(www.error);
    	}
    	else {
    		processJsonData(www.downloadHandler.text);
    	}
    }

    private void processJsonData(string _url) {
    	Diamond jsnData = JsonUtility.FromJson<Diamond>(_url);
    	Debug.Log(jsnData.playerName);
    	Debug.Log(jsnData.balls);
    	// Debug.Log(jsnData.data);
    }

    // --------------------------**POST**---------------------------

    IEnumerator postData() {
    	List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
    	wwwForm.Add(new MultipartFormDataSection("name", "ishaan"));

    	UnityWebRequest www = UnityWebRequest.Post(postUrl, wwwForm);

    	yield return www.SendWebRequest();

    	if (www.isNetworkError || www.isHttpError) {
    		Debug.LogError("Networking Dikkat hai");
    		Debug.LogError(www.error);
    	}
    	else {
    		Debug.Log("Sahi");
    		Debug.Log(www.downloadHandler.text);
    	}
    }
}
