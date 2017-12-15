using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;

	private Button[] buttonArray;
	private Text costText;
	public static GameObject selectedDefender;


	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		costText = GetComponentInChildren<Text> ();
		if (!costText) {
			Debug.LogWarning (name + "has no text");
		}

		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString();
	}
	

	void OnMouseDown () {

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		
		}

		GetComponent<SpriteRenderer> ().color = Color.white;

		selectedDefender = defenderPrefab;
	}
}
