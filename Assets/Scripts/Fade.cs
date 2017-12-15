using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour {


	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;


	void Start () {
		fadePanel = GetComponent<Image> ();

	}

	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			// fade in
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);
		}
	}


	/*
	private bool _fadeOver = false;
	private CanvasGroup cg;

	public void FadeIn() {
		
		cg.alpha -= 1.0f / fadeInTime * Time.deltaTime;
		if (cg.alpha == 0f) {
			_fadeOver = true;
		}
	}

	

	void Start () {
		cg = GetComponent<CanvasGroup> ();
		cg.alpha = 1;
	}
	
	
	void Update () {
		if (!_fadeOver) {
			FadeIn ();
		}
	}

	*/
}
