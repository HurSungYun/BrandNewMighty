using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using LitJson;

public class NetworkManager : MonoBehaviour {

	private string ServerUrl;

	private Http http;

	public void hello(){
		Debug.Log ("hello");
	}

	void Start() {          
		ServerUrl = "http://192.168.0.27:8080";

		GameObject go = GameObject.Find ("Http");
		http = (Http)go.GetComponent (typeof(Http));

//		WWW result = http.GET(ServerUrl);
		PostEvent(null,null);
	} 

	void OnEnable ()  {
		EventManager.StartListening ("getPlayedEvent", GetPlayed);
		EventManager.StartListening ("getPledgedEvent", GetPledged);
		EventManager.StartListening ("getDiscardedEvent", GetDiscarded);
		EventManager.StartListening ("getDealMissedEvent", GetDealMissed);
		EventManager.StartListening ("getDealedEvent", GetDealed);
		EventManager.StartListening ("getRoundEndedEvent", GetRoundEnded);
		EventManager.StartListening ("getGameEndedEvent", GetGameEnded);
	}

	void OnDisable ()  {
		EventManager.StopListening ("getPlayedEvent", GetPlayed);
		EventManager.StopListening ("getPledgedEvent", GetPledged);
		EventManager.StopListening ("getDiscardedEvent", GetDiscarded);
		EventManager.StopListening ("getDealMissedEvent", GetDealMissed);
		EventManager.StopListening ("getDealedEvent", GetDealed);
		EventManager.StopListening ("getRoundEndedEvent", GetRoundEnded);
		EventManager.StopListening ("getGameEndedEvent", GetGameEnded);
	}

	public void Callback (JsonData result){
		Debug.Log ("entered");
		Debug.Log (result["messageType"]);
		Debug.Log (result ["clientId"]);
		Debug.Log (result ["secret"]);

		//TODO: check event type and pass JsonData to function

		//ex: if(eventType == "play") GetPlayed(result);

	}

	//These functions are triggered by HTTP 

	void GetPlayed(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
	}

	void GetPledged(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
	}

	void GetDiscarded(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
	}

	void GetDealMissed(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
	}

	void GetDealed(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
		//GameManager.dealed(var a[10]);
	}

	void GetRoundEnded(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
	}

	void GetGameEnded(EventDataType result){
		//TODO: send information to GameManager with appropriate format 
	}

	public void PostEvent(string eventName, EventDataType obj){
		//TODO: make HTTP Class post events

		//TODO: convert EventDataType into Dictionary<string, string> form

		Dictionary<string, string> dictionary = new Dictionary<string, string>();

		dictionary.Add ("god", "jangho");
		dictionary.Add ("weare", "overwatch");

		WWW result = http.POST("http://192.168.0.27:8080", dictionary);
		// check error
	}
}
