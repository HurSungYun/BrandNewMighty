using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

	private UnityAction playedListener;

	void Awake () {
		playedListener = new UnityAction (PlayedFunction);
	}

	void OnEnable ()  {
		EventManager.StartListening ("played", playedListener);
	}

	void OnDisable ()  {
		EventManager.StopListening ("played", playedListener);
	}

	void PlayedFunction ()  {
		Debug.Log ("Some Card was played!");
	}

}