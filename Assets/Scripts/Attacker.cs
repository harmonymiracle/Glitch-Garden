using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Health))]
[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between apperances")]
	public float _seenEverySecond;

	private float _currentSpeed = .4f;

	private GameObject _currentTarget;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}


	void Update () {
		transform.Translate (new Vector3 (- _currentSpeed * Time.deltaTime, 0f, 0f));
		if (!_currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		print (name + "trigger enter");
	}

	public void SetSpeed (float speed) {
		_currentSpeed = speed;
	}

	// this will be call by anim events.
	public void StrikeCurrentTarget (float damage) {
		if (_currentTarget) {
			Health health = _currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}

	}

	public void Attack (GameObject obj) {
		_currentTarget = obj;
	}



}
