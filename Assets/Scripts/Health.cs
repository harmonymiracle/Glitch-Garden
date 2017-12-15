using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100f;

	public void Start () {
		Defender defender = GetComponent<Defender> ();
		if (defender) {
			print (GlobalSettings.Difficulty);
			health /= GlobalSettings.Difficulty;
		}
	}

	public void DealDamage (float damage) {

		health -= damage;
		if (health <= 0) {
			DestroyThisObject ();
		}

	}

	/// <summary>
	/// Destroies the object.
	/// </summary>
	public void DestroyThisObject () {
		Destroy (gameObject);
	}

}
