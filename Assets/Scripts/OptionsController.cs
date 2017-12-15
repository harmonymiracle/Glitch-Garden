using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSilder;
	public Slider difficultySilder;
	public LevelManager levelManager;

	private MusicManager musicManager;

	void Start () {
		
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
        

		volumeSilder.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySilder.value = PlayerPrefsManager.GetDifficulty ();
	}
	
	
	void Update () {
		
		musicManager.SetVolume (volumeSilder.value);

	}

	public void SaveAndExit() {
		PlayerPrefsManager.SetMasterVolume (volumeSilder.value);
		PlayerPrefsManager.SetDifficulty (difficultySilder.value);
		GlobalSettings.Difficulty = difficultySilder.value;
		levelManager.LoadLevel ("01a Start");
	}

	public void SetDefaluts () {
		volumeSilder.value = .4f;
		difficultySilder.value = 1f;
	}
}
