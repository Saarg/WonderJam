using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameUI : MonoBehaviour {

	[SerializeField]
	Text team1Score;
	[SerializeField]
	Text team1Result;

	[SerializeField]
	Text team2Score;
	[SerializeField]
	Text team2Result;

	GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.GetInstance();

		if (gameManager.teams.Length > 1) {
			int t1Score = gameManager.teams[0].score;
			int t2Score = gameManager.teams[1].score;

			team1Score.text = t1Score.ToString() + " points";

			team2Score.text = t2Score.ToString() + " points";

			team1Result.text = t1Score > t2Score ? "Victory !" : "Loser";
			team2Result.text = t2Score > t1Score ? "Victory !" : "Loser";
		} else {
			int t1Score = gameManager.teams[0].score;
			
			team1Score.text = t1Score.ToString() + " points";

			team1Score.transform.parent.Translate(160, 0, 0);

			team2Score.transform.parent.gameObject.SetActive(false);
			team1Result.gameObject.SetActive(false);
		}
	}
}
