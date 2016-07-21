using UnityEngine; 
using System.Collections; 
using System.Collections.Generic; 
using System.Text; 
using System.IO; 
using System.Net;

// Referenced from http://stackoverflow.com/questions/8951489/unity-get-post-wrapper

public class Http : MonoBehaviour {

	private string ServerUrl;

	// Use this for initialization 
	void Start() {          
		ServerUrl = "http://cse.snu.ac.kr";
/*		WWW result = GET(ServerUrl);
		Debug.Log(result.text); */

	} 

	//TODO: I think we should not use just GET. What should we do?
	WWW GET(string url) { 
		WWW www = new WWW(url); 
		StartCoroutine(WaitForRequest(www)); 

		//TODO: check which event and error

		// EventManager.TriggerEvent(eventName, obj);

		return www; 
	} 

	WWW POST(string url, Dictionary<string, string> post) { 

		WWWForm form = new WWWForm(); 

		foreach (KeyValuePair<string, string> post_arg in post) { 
			form.AddField(post_arg.Key, post_arg.Value); 
		} 

		WWW www = new WWW(url, form); 
		StartCoroutine(WaitForRequest(www)); 
		return www; 

	} 

	private IEnumerator WaitForRequest(WWW www)  { 
		yield return www; 
		// check for errors 
		if (www.error == null)  { 
			Debug.Log("WWW Ok!: " + www.text); 
		} 
		else { 
			Debug.Log("WWW Error: " + www.error); 
		} 
	} 
}
