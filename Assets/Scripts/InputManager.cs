using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			var wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (wp, Vector2.zero);

			if (hit.collider) {  //TODO: how we treat other buttons
				Debug.Log (hit.collider.gameObject.name);

				Card selectedCard = hit.collider.gameObject.GetComponent<Card> ();
				if (selectedCard != null) {
					selectedCard.tryPlay ();
				}
			}
		}
	}
}