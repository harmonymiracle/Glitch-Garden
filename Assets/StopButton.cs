using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {


	private LevelManager levelManager;
	private bool isPausing = false;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	


	public void OnMouseDown () {
		if (isPausing) {
			Time.timeScale = 1f;
		} else {
			Time.timeScale = 0f;
		}
		isPausing = !isPausing;

	}
}
