using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MightyEvent : UnityEvent<object>
{
}


public class EventManager : MonoBehaviour {

	public delegate void DelegatedFunction (object obj);

	private Dictionary <string, MightyEvent> eventDictionary;
	private static EventManager eventManager;

	public static EventManager instance	{
		get	{
			if (!eventManager)	{
				
				eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;
				if (!eventManager)  {
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else{
					eventManager.Init(); 
				}
			}
			return eventManager;
		}
	}

	void Init () {
		if (eventDictionary == null) {
			eventDictionary = new Dictionary<string, MightyEvent>();
		}
	}

	public static void StartListening (string eventName, UnityAction<object> listener)  {
		MightyEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.AddListener (listener);
		} 
		else {
			thisEvent = new MightyEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void StopListening (string eventName, UnityAction<object> listener) {
		if (eventManager == null) return;
		MightyEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))  {
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName, object obj)	{
		MightyEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))  {
			thisEvent.Invoke (obj);
		}
	}
}