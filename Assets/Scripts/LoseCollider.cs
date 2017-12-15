using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	LevelManager _levelManager;

	void Start () {
		_levelManager = GameObject.FindObjectOfType<LevelManager> ();

	}


	void OnTriggerEnter2D () {
		_levelManager.LoadLevel ("03b Lose");
	}
}
