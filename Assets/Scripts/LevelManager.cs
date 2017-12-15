using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel;

	void Awake(){
		
	}

	public void Start() {
		if (autoLoadNextLevel <= 0) {
			print ("level auto load disabled, use a positive number");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevel);

		}
	}
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		UnityEngine.SceneManagement.SceneManager.LoadScene (name);
		//Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	public void LoadNextLevel(){
		
		//UnityEngine.SceneManagement.SceneManager.LoadScene (name);
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
