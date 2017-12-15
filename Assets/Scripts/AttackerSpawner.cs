using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if (IsTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	bool IsTimeToSpawn (GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		// attacker._seenEverySecond mean that after which second you can see it.
		// spawnDelay mean that after last one spawn, you will wait ? s can see next one
		// they are equavance, usually maybe a big number, like 10,20
		float meanSpawnDelay = attacker._seenEverySecond;

		// how many spawn in 1 s 
		float spawnPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		// multiply Time.deltaTime because we call the mathod in Update
		float threshold = spawnPerSecond * Time.deltaTime;

		return Random.value < threshold;


	}

	void Spawn (GameObject myGameobject) {
		GameObject myAttacker = Instantiate (myGameobject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

}
