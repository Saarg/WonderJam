using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamNumber { Team1, Team2 }

[Serializable]
public class TeamData {
	public int score { get; internal set; } = 0;

	public void AddScore(int s) {
		score += s;
	}
}

public class GameManager : MonoBehaviour {

	static GameManager gameManager;
	static public GameManager GetInstance() { return gameManager; }

	public TeamData[] scores;

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

		gameManager = this;

		_startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		curTime = Time.realtimeSinceStartup - _startTime;
	}

	public void AddScore(int s, TeamNumber team) {
		scores[(int)team].AddScore(s);
	}
}
