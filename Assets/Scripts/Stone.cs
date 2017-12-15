using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private Animator _anim;

	
	void Start () {
		_anim = GetComponent<Animator> ();

	}
	
	
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D col) {
		Attacker attacker = col.GetComponent<Attacker> ();
		//if (col.CompareTag())

		if (attacker) {
			_anim.SetTrigger ("underAttack trigger");
		} else {
			Debug.LogError ("what happened");
		}
	}
}
