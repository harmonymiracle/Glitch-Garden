using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;

	private AttackerSpawner myLaneSpawner;


	void Start () {
		animator = GetComponent<Animator> ();

		// create a parent if necessary
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update () {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	void SetMyLaneSpawner () {
		AttackerSpawner[] allSpawner = GameObject.FindObjectsOfType<AttackerSpawner> ();
		foreach (AttackerSpawner spawner in allSpawner) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
	}

	bool IsAttackerAheadInLane() {

		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		foreach (Transform child in myLaneSpawner.transform) {
			if (child.transform.position.x > transform.position.z) {
				return true;
			}
		}
		return false;
	}



	private void Fire () {
		GameObject newProjectile =  Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
