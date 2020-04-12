using System.Collections;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{

	public string jsonURL;

    void Start()
    {
    	StartCoroutine(getData());
    }

    IEnumerator getData() {
    	Debug.Log("Processing Data..");

    	WWW _www = new WWW(jsonURL);
    	yield return _www;

    	if (_www.error == null) {
    		processJsonData(_www.text);
    	} else {
    		Debug.Log("Networking Dikkat hai");
    	}
    }

    private void processJsonData(string _url) {
    	Diamond jsnData = JsonUtility.FromJson<Diamond>(_url);
    	// Debug.Log(jsnData.playerName);
    	// Debug.Log(jsnData.balls);
    	Debug.Log(jsnData.data);
    }
}
