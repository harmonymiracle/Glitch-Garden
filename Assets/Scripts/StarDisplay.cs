using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class StarDisplay : MonoBehaviour {

	private Text starAmountText;
	private int starAmount = 100;

	public enum Status {
		FAILURE,
		SUCCESS
	}

	void Start () {
		starAmountText = GetComponent<Text> ();
		UpdateDisplay ();
	}
	

	public void AddStars (int amount) {
		starAmount += amount;
		UpdateDisplay ();
	}

	public Status UseStars (int amount) {
		if (starAmount >= amount) {
			starAmount -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;

			
	}

	private void UpdateDisplay () {
		starAmountText.text = starAmount.ToString();
	}

}
