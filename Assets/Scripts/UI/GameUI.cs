using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	[Header("Players")]
	[SerializeField]
	private GameObject _player;
	private WheelVehicle _playerVehicle;
	private Player _playerStats;
	public GameObject player { set { 
		_player = value;
		_playerVehicle = _player.GetComponent<WheelVehicle>();
		_playerStats = _player.GetComponent<Player>();
	} }
	
	private GameObject[] _teamMates;

	[Header("PlayerUI")]
	[SerializeField]
	private Image _lifeBar;
	[SerializeField]
	private Text _score;
	[SerializeField]
	private Text _time;
	[SerializeField]
	private Image _speedo;

	private GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = GetComponent<GameManager>();

		if (_player != null) {
			_playerVehicle = _player.GetComponent<WheelVehicle>();
			_playerStats = _player.GetComponent<Player>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_gameManager != null) {
			_score.text = _gameManager.score.ToString();

			float timeLeft = _gameManager.timeLeft;

			StringBuilder sb = new StringBuilder();
			sb.Append(((int)(timeLeft/60)).ToString());
			sb.Append(":");
			sb.Append(((int)(timeLeft%60)).ToString());
			_time.text = sb.ToString();

			if (timeLeft < 5) {
				_time.color = Color.red;

				_time.transform.localScale = Vector3.one * (1f + timeLeft%1 * (5 - (int)(timeLeft)) / 20);
			} else {
				_time.color = Color.black;

				_time.transform.localScale = Vector3.one * (1f + timeLeft%1  / 20);         
			}
		}

		if (_player != null) {
			_speedo.transform.rotation = Quaternion.Euler(0, 0, _playerVehicle.speed / 200f * -160f);

			_lifeBar.fillAmount = Mathf.Lerp(_lifeBar.fillAmount, _playerStats.life / _playerStats.maxlife, Time.deltaTime * 2f);
		}
	}
}
