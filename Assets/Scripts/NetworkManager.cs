using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

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

	//These functions are triggered by HTTP 

	public void GetPlayed(object obj){
		//TODO: parse data and send information to GameManager
	}

	public void GetPledged(object obj){
		//TODO: parse data and send information to GameManager
	}

	public void GetDiscarded(object obj){
		//TODO: parse data and send information to GameManager
	}

	public void GetDealMissed(object obj){
		//TODO: parse data and send information to GameManager
	}

	public void GetDealed(object obj){
		//TODO: parse data and send information to GameManager
		//GameManager.dealed(var a[10]);
	}

	public void GetRoundEnded(object obj){
		//TODO: parse data and send information to GameManager
	}

	public void GetGameEnded(object obj){
		//TODO: parse data and send information to GameManager
	}

	public void PostEvent(string eventName, object obj){
		//TODO: make HTTP Class post events

		//TODO: convert object into Dictionary<string, string> form

		// result = Http.POST(url, postObject);
		// check error
	}
}
