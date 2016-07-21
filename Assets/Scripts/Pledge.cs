using UnityEngine;
using System.Collections;

public class Pledge : MonoBehaviour {
	public Type type;
	public int score;
	public Player player;

	public int UpdateInfo(Pledge pled)
	{
		this.type = pled.type;
		this.score = pled.score;
		this.player = new Player (pled.player);
	}

	public override string ToString ()
	{
		return string.Format ("type: " + type + "score: " + score + "player: " + player.ToString());
	}
}
