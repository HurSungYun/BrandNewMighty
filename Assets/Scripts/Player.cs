using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerId;		// 0~5
	private string playerName;	// asdf#1234
	private int currScore;
	public int side; //0: 주공 1: 프렌드 2: 야당 3: 미정

	/*
	public int Mine {
		//get { return mine; }
		set {  = value; }
	}
	*/

	public override string ToString ()
	{
		return string.Format (playerId);
	}

	public void updateScore(int num)
	{
		currScore += num;
	}

	public bool Equals (Player o)
	{
		if (this.playerId != o.playerId)
			return false;
		if (!this.playerName.Equals (o.playerName))
			return false;

		return true;
	}

	public Player(Player player) {
		this.playerId = player.playerId;
		this.playerName = player.playerName;
		this.currScore = player.currScore;
		this.side = player.side;
	}
}