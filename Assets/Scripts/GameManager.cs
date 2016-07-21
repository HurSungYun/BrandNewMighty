using UnityEngine;
using System.Collections;

public enum Type { 
	Spade, Diamond, Heart, Club, No, GiveUp
};

public class GameManager : MonoBehaviour {
	// Few Essential Constants
	public const int MIGHTY5_MY = 10;
	public const int MIGHTY6_MY = 8;
	public const int MIGHTY5_OPTION = 3;
	public const int MIGHTY6_OPTION = 5;
	public const int MIGHTY5 = 5;
	public const int MIGHTY6 = 6;

	// To control Prefabs
	public GameObject MyCards;
	public GameObject OptionCards;
	public GameObject ThrownCards;

	// Information to handle
	private Card[] myCard;
	private Card[] optionCard;
	private Card[] thrownCard;
	private Pledge currPledge;
	private Player[] players;

	// Use this for initialization
	void Start () {
		myCard = new Card[MIGHTY5_MY];
		optionCard = new Card[MIGHTY5_OPTION];
		players = new Player[MIGHTY5];
		MyCards = GameObject.FindGameObjectWithTag ("Card");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void getShuffledInfo(/* May be changed */string[] cards) {
		for (int i = 0; i < MIGHTY5_MY; i++) {
			myCard [i] = new Card (int.Parse (cards [i]) / 10, int.Parse (cards [i]) % 10);
		}
	}

	public void PledgeUpdated(Pledge pled){
		//TODO: If type is GiveUp, should be ignored
		this.currPledge.UpdateInfo(pled);
		Debug.Log ("New Pledge: " + this.currPledge.ToString ());
	}

	public void ClaimPledge(Pledge pled){
		NetworkManager.PostEvent ("pledge", pled);
	}

	public void ClaimDealMiss() {
		NetworkManager.PostEvent ("dealmiss", null);
		Debug.Log ("Claim Deal Miss");
	}

	public void PresidentSet(Player player) {
		int i;
		for(i=0; i<5; i++) {
			if(players[i].Equals(player))
				break;
		}
		Debug.Log ("President Set" + player.ToString () + "i:" + i);
		players [i].side = 0; //주공 플레이어 side setting
	}

	public void GetOptionalCards (/* May be changed */string[] cards) {
		for (int i = 0; i < MIGHTY5_OPTION; i++) {
			optionCard [i] = new Card (int.Parse (cards [i]) / 10, int.Parse (cards [i]) % 10);
		}
	}

	public void ConfirmFinalPledgeInfo() {
		NetworkManager.PostEvent ("confirmpledge", Pledge);
	}

	//TODO: Procrastinate
	public void SetFriendInfo() {
		NetworkManager.PostEvent ("setfriend", object /* ... */);
	}

	public void DiscardOptionalCards() {
	}

	public void GetFinalPledge() {
	}

	public void GetFriendInfo() {
	}

	public void GetThrownCardInfo() {
	}

	public void SetFirstPattern() {
	}

	public void GetRoundResultInfo() {
	}

	public void GetGameResultInfo() {
	}

	public void ClearGame() {
	}
}
