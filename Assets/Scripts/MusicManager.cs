using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		print ("dont destroy on load" + name);
	}

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}

	void OnEnable() {
		SceneManager.activeSceneChanged += OnSceneLoaded;
	}

	void OnDisable() {
		SceneManager.activeSceneChanged -= OnSceneLoaded;
	}
		


	void OnSceneLoaded(Scene lastScene, Scene newScene) {
		AudioClip audioClip = levelMusicChangeArray [newScene.buildIndex];
		if (!audioClip)
			return;
		audioSource.clip = audioClip;
		audioSource.loop = true;
		audioSource.Play ();
	}


	public void SetVolume (float volume){
		audioSource.volume = volume;
	}
}
