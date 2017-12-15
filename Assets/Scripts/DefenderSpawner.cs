using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarDisplay starDisplay;


	void Start () {
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}


	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);

		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;

		if (starDisplay.UseStars(defender.GetComponent<Defender>().starCost) == StarDisplay.Status.SUCCESS){
			SpawnDefender (roundedPos, defender);

		} else {
			print ("insufficient stars");
		}


	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender) {
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRot);

		newDef.transform.parent = parent.transform;

	}



	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	Vector3 CalculateWorldPointOfMouseClick () {

		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPoint = Camera.main.ScreenToWorldPoint (weirdTriplet);


		return worldPoint;

		/*  obsolete

		private float size = 50f;
		private float yOffset = 45f;

		Vector2 screenPoint = new Vector2 (mousePos.x, mousePos.y);

		worldPoint.x = (float)((int)(mousePos.x  / size + 1f));
		worldPoint.y = (float)((int)((mousePos.y - yOffset) / size + 1f));
		*/
	}



}
