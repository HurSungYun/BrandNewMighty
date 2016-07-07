using UnityEngine;
using System.Collections;

//TODO: Modify to fit into our project(This is from Syria Game)
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	private static T _instance;
	public static GameObject gameController;
	public static void instantiateSingleton() {
		_instance = instance;
	}
	public static T instance {
		get {
			if( _instance == null ) {
				gameController = GameObject.FindGameObjectWithTag ("GameController");
				if (gameController == null) {
					gameController = new GameObject ("GameController");
					gameController.tag = "GameController";
					DontDestroyOnLoad (gameController);
				}
				_instance = gameController.AddComponent<T> ();
			}
			return _instance;
		}
	}
}


public class RuleManager : Singleton<RuleManager> {


}
