using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour {
	private int health;

	void Start() {
		health = 5;
	}

	public void Hurt(int damage) {
		health -= damage;
		Debug.Log($"Health: {health}");
		if (health <= 0) {
			SceneManager.LoadScene(0);
		}
	}
}
