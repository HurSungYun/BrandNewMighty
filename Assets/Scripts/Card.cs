using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Card : MonoBehaviour {

	private bool ableToPlay = false;

	void OnEnable ()  {
		EventManager.StartListening (this.gameObject.name + "played", PlayFunction);
		ableToPlay = true;
	}

	void OnDisable ()  {
		EventManager.StopListening (this.gameObject.name + "played", PlayFunction);
		ableToPlay = false;
	}

	void PlayFunction (object cardInfo)  {
		Debug.Log (this.gameObject.name + " was played!");
	}

	void SetInfo(int type, int num){

	}

	public void TryPlay(){
		if (ableToPlay || true) {
			//TODO: play card
//			Debug.Log(this.gameObject.name + " played");
			EventManager.TriggerEvent (this.gameObject.name + "played", null);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
