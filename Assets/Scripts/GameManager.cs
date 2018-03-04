using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamNumber { Team1, Team2 }

[Serializable]
public class TeamData {
	public Transform spawn1;
	public GameObject player1;
	[HideInInspector]
	public PlayerUI player1UI;
	public Transform spawn2;
	
	public GameObject player2;
	[HideInInspector]	
	public PlayerUI player2UI;
	

	public int score { get; internal set; } = 0;

	public void AddScore(int s) {
		score += s;
	}
}

public class GameManager : MonoBehaviour {

	static GameManager gameManager;
	static public GameManager GetInstance() { return gameManager; }

	GameUI gameUI;

	[SerializeField]
	GameObject[] cars;

	public GameObject playerUIPrefab;
	public TeamData[] teams;

	public GameObject countdownUIPrefab;	
	public GameObject endOfGameUIPrefab;	

	[SerializeField]
	private float _gameTime = 600f;
	public float curTime { get; internal set; } = 0;
	public float timeLeft { get { return _gameTime - curTime; } }
	private float _startTime = 0;

	// Use this for initialization
	void Start () {
		if (gameManager != null) {
			Debug.LogError("Multiple gameManagers in scene");
			Destroy(gameObject);
		}

		if (countdownUIPrefab != null) {
			Instantiate(countdownUIPrefab, transform);
			_gameTime += 5;
		}

		gameManager = this;
		gameUI = GetComponent<GameUI>();

		_startTime = Time.realtimeSinceStartup;

		int playernum = 0;
		int teamnum = 0;
		Camera cam;
		PlayerNumber pn;
		foreach (TeamData t in teams) {
            t.player1 = Instantiate(cars[PlayerPrefs.GetInt("Player" + (playernum+1) + "Car")], t.spawn1.position, t.spawn1.rotation);
			t.player1UI = Instantiate(playerUIPrefab, transform).GetComponent<PlayerUI>();
			t.player1UI.player = t.player1;
			cam = t.player1.GetComponentInChildren<Camera>();
			t.player1UI.GetComponent<Canvas>().worldCamera = cam;
			t.player1.GetComponent<Player>().team = (TeamNumber)(teamnum);
		    t.player1.GetComponent<Player>().animator = t.player1UI.GetComponent<Animator>();
			pn = (PlayerNumber)(playernum);
			t.player1.GetComponent<WheelVehicle>().playerNumber = pn;

			if (pn == PlayerNumber.Player1)
				cam.rect = new Rect(0f, 0f, teams.Length == 1 ? 1f : 0.5f, t.player2 == null ? 1f : 0.5f);
			else if (pn == PlayerNumber.Player2)
				cam.rect = new Rect(0.5f, 0f, 0.5f, t.player2 == null ? 1f : 0.5f);
			else if (pn == PlayerNumber.Player3)
				cam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			else if (pn == PlayerNumber.Player4)
				cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);

			gameUI.players.Add(t.player1UI);
			playernum++;					

			if (t.player2 != null) {
				t.player2 = Instantiate(cars[PlayerPrefs.GetInt("Player" + (playernum+1) + "Car")], t.spawn2.position, t.spawn2.rotation);
				t.player2UI = Instantiate(playerUIPrefab, transform).GetComponent<PlayerUI>();
				t.player2UI.player = t.player2;
				cam = t.player2.GetComponentInChildren<Camera>();				
				t.player2UI.GetComponent<Canvas>().worldCamera = t.player2.GetComponentInChildren<Camera>();			
				t.player2.GetComponent<Player>().team = (TeamNumber)(teamnum);
			    t.player2.GetComponent<Player>().animator = t.player2UI.GetComponent<Animator>();
                pn = (PlayerNumber)(playernum);
				t.player2.GetComponent<WheelVehicle>().playerNumber = pn;

				if (pn == PlayerNumber.Player1)
					cam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
				else if (pn == PlayerNumber.Player2)
					cam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
				else if (pn == PlayerNumber.Player3)
					cam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
				else if (pn == PlayerNumber.Player4)
					cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);		

				gameUI.players.Add(t.player2UI);

				playernum++;
			}
			teamnum++;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		curTime = Time.realtimeSinceStartup - _startTime;

        if (curTime >= _gameTime) {
			if (endOfGameUIPrefab != null && teams[0].player1UI != null) {
				foreach (TeamData td in teams)
					Destroy(teams[0].player1UI.gameObject);

				Instantiate(endOfGameUIPrefab, transform);
			}
		}
	}

	public void AddScore(int s, TeamNumber team) {
		teams[(int)team].AddScore(s);
	}
}
