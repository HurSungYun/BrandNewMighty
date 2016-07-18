using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private bool ableToPlay = false;

	void OnEnable ()  {
		EventManager.StartListening (this.gameObject.name + "played", PlayFunction);
	}

	void OnDisable ()  {
		EventManager.StopListening (this.gameObject.name + "played", PlayFunction);
	}

	void PlayFunction ()  {
		Debug.Log (this.gameObject.name + " was played!");
	}

	void setInfo(int type, int num){

	}

	public void tryPlay(){
		if (ableToPlay || true) {
			//TODO: play card
//			Debug.Log(this.gameObject.name + " played");
			EventManager.TriggerEvent (this.gameObject.name + "played");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
