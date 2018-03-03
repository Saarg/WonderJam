using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	
	private GameObject[] _teamMates;

	[Header("PlayerUI")]
	public List<PlayerUI> players = new List<PlayerUI>();

	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GetComponent<GameManager>();

		foreach (PlayerUI ui in players) {
			if (ui.player != null) {
				ui.playerVehicle = ui.player.GetComponent<WheelVehicle>();
				ui.playerStats = ui.player.GetComponent<Player>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (PlayerUI ui in players) {
			if (_gameManager != null) {
				ui.score.text = _gameManager.teams[(int)ui.playerStats.team].score.ToString();

				float timeLeft = _gameManager.timeLeft;

				StringBuilder sb = new StringBuilder();
				sb.Append(((int)(timeLeft/60)).ToString());
				sb.Append(":");
				sb.Append(((int)(timeLeft%60)).ToString());
				ui.time.text = sb.ToString();

				if (timeLeft < 5) {
					ui.time.color = Color.red;

					ui.time.transform.localScale = Vector3.one * (1f + timeLeft%1 * (5 - (int)(timeLeft)) / 20);
				} else {
					ui.time.color = Color.black;

					ui.time.transform.localScale = Vector3.one * (1f + timeLeft%1  / 20);         
				}
			}

			if (ui.player != null) {
				ui.speedo.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Abs(ui.playerVehicle.speed) / 200f * -160f);

				ui.lifeBar.fillAmount = Mathf.Lerp(ui.lifeBar.fillAmount, ui.playerStats.life / ui.playerStats.maxlife, Time.deltaTime * 2f);
				ui.boostBar.fillAmount = Mathf.Lerp(ui.boostBar.fillAmount, ui.playerStats.boost / ui.playerStats.maxBoost, Time.deltaTime * 2f);
			}
		}
	}
}
