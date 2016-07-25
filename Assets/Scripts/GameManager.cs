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
	/*
	public GameObject MyCards;
	public GameObject OptionCards;
	public GameObject ThrownCards;
	*/

	// Information to handle
	private Card[] myCards;
	private Card[] optionCards;
	private Card[] thrownCards;
	private Pledge currPledge;	// 현재 공약
	private Player[] players;
	private Type firstType;
	private int firstPlayer;

	// Use this for initialization
	void Start () {
		myCards = new Card[MIGHTY5_MY];
		optionCards = new Card[MIGHTY5_OPTION];
		players = new Player[MIGHTY5];
		//MyCards = GameObject.FindGameObjectWithTag ("Card");
		firstType = Type.GiveUp;
	}
	
	// Update is called once per frame
	void Update () {
	}

	//서버로부터 셔플되어 온 10장의 카드 정보를 받아온다
	public void getShuffledInfo(/* May be changed */string[] cards) {
		for (int i = 0; i < MIGHTY5_MY; i++) {
			myCards [i] = new Card (int.Parse (cards [i]) / 10, int.Parse (cards [i]) % 10);
		}
	}

	// 다른 플레이어가 공약한 내용을 가져와서 디스플레이해준다
	public void PledgeUpdated(Pledge pled){
		//TODO: If type is GiveUp, should be ignored
		this.currPledge.UpdateInfo(pled);
		Debug.Log ("New Pledge: " + this.currPledge.ToString ());
	}

	// 내가 더 높은 공약을 불러, 그 내용을 서버에 전달한다. (포기하는 것도 포함)
	public void ClaimPledge(Pledge pled){
		NetworkManager.PostEvent ("pledge", pled);
	}

	// 딜미스인 경우, 딜미스라고 서버에 전달한다
	public void ClaimDealMiss() {
		NetworkManager.PostEvent ("dealmiss", null);
		Debug.Log ("Claim Deal Miss");
	}

	// 주공이 확정되었다는 정보를 서버로부터 전달받는다
	public void PresidentSet(Player player) {
		int i;
		for(i=0; i<5; i++) {
			if(players[i].Equals(player))
				break;
		}
		Debug.Log ("President Set" + player.ToString () + "i:" + i);
		players [i].side = 0; //주공 플레이어 side setting
	}

	// (주공일 경우) 3장의 추가 카드를 받는다
	public void GetOptionalCards (/* May be changed */string[] cards) {
		for (int i = 0; i < MIGHTY5_OPTION; i++) {
			optionCards [i] = new Card (int.Parse (cards [i]) / 10, int.Parse (cards [i]) % 10);
		}
	}

	// (주공일 경우) 공약을 최종적으로 확정하거나 변경하고, 서버에 전달한다
	public void ConfirmFinalPledgeInfo() {
		NetworkManager.PostEvent ("confirmpledge", Pledge);
	}

	//TODO: Procrastinate
	// (주공일 경우) 프렌드를 지정하고, 서버에 전달한다
	public void SetFriendInfo() {
		NetworkManager.PostEvent ("setfriend", null /* ... */);
	}

	// (주공일 경우) 버리는 카드 3장을 확정하고, 서버에 전달한다
	public void DiscardOptionalCards(Card[] discard) {
		NetworkManager.PostEvent ("discardoptionalcards", null);
	}

	// (모두) 최종적으로 확정된 공약 정보를 전달받는다
	public void GetFinalPledge(Pledge pled) {
		currPledge.UpdateInfo (pled);
	}

	// 확정된 프렌드 정보를 전달받는다
	public void GetFriendInfo(/* something */) {
		for (int i = 0; i < MIGHTY5; i++) {
			if (players [i].Equals (null /* something */)) {
				players [i].side = 1;
			}
		}
	}

	// 다른 플레이어들이 낸 카드 정보를 전달받는다
	public void GetThrownCardInfo(Player player, Card card) {
		thrownCards [player.playerId].SetInfo (card.getType (), card.getNumber ());
	}

	//TODO
	// ( Get ThrownCardInfo() 에서 선 카드를 낸 경우 ) 선문양 정보를 갱신한다
	public void SetFirstPattern(Type type) {
		firstType = type;	//인자가 뭐 올지?
	}

	// 라운드가 끝난 결과와, 누가 새로운 선인지 전달한다
	public void GetRoundResultInfo(Player winner, int cards) {
		for (int i = 0; i < MIGHTY5; i++) {
			if (players [i].Equals (winner)) {
				players [i].updateScore (cards);
				firstPlayer = winner.playerId;
			}
		}
	}

	// 게임이 끝난 결과를 전달한다
	public void GetGameResultInfo() {
	}

	// 모든 세팅을 초기화하여 다음 판을 준비한다
	public void ClearGame() {
		myCards = new Card[MIGHTY5_MY];
		optionCards = new Card[MIGHTY5_OPTION];
		players = new Player[MIGHTY5];
		firstType = Type.GiveUp;
	}
}
