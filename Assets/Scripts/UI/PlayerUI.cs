using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerUI : MonoBehaviour {
	[SerializeField]
	private GameObject _player;
	public WheelVehicle playerVehicle { get; internal set; }
	public Player playerStats { get; internal set; }
	public GameObject player { set { 
		_player = value;
		playerVehicle = _player.GetComponent<WheelVehicle>();
		playerStats = _player.GetComponent<Player>();
	} 
	get {
		return _player;	
	}}

	public Image lifeBar;
	public Image boostBar;
	public Text score;
	public Text time;
	public Image speedo;
}
