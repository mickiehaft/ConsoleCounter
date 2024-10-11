using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;

	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		// "other" is a reference to the Collider attached to the object that the fireball collided with
		Debug.Log("Hit: " + other.gameObject.name);	
		// If we wanted to check the type of object that the fireball collided with, we could do this:
		if (other.gameObject.name == "Player") {
			// We are assuming that we collided with the player—a safe assumption given that it's the only
			// other thing in the scene. NOT a safe assumption for a more complex project!
			// 1. Declaring a variable of type PlayerCharacter
			// 2. Assigning it to the PlayerCharacter component of the object that the fireball collided with
			PlayerCharacter player = other.GetComponent<PlayerCharacter>();

			// Before we do anything, we check to verify that the PlayerCharacter instance is actually there
			if (player != null) {
				// Calling the "Hurt" method on the PlayerCharacter instance, which is attached to the player object
				player.Hurt(damage);
			}
		} else {
			Debug.Log("Hit something other than the player: " + other.gameObject.name);
			// TODO: Add enemy hurting code here if it's an enemy
		}

		// Destroying the object this script is attached to
		Destroy(this.gameObject);
	}
}
