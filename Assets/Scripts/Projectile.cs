using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


	public float speed;
	private float rotateSpeed = 360f;
	public float damage;

	void Start () {
		
	}
	
	
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D (Collider2D col) {
		Attacker attacker = col.GetComponent<Attacker> ();
		Health health = col.GetComponent<Health> ();

		if (attacker && health) {
			health.DealDamage (damage);
			Destroy (gameObject);
		}
	}

}
