using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DiamondScript : MonoBehaviour
{

	public string jsonURL;

    void Start()
    {
    	StartCoroutine(getData());
    }

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
    	// Debug.Log(jsnData.playerName);
    	// Debug.Log(jsnData.balls);
    	Debug.Log(jsnData.data);
    }
}
