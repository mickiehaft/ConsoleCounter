using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

public float deathTimer = 1.5f;
private int health;

	void Start() {
		health = 5;
	}
	public void ReactToHit(int damage) {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			health -= damage;
			StartCoroutine(Ouch());
		}

		if (health <= 0) {
			if (behavior != null) {
				behavior.SetAlive(false);
			}
			StartCoroutine(Die(deathTimer));
		}
	}

	private IEnumerator Ouch() {
		Color currentColor = gameObject.GetComponent<Renderer>().material.color;
		// Run this code before we start the timer
		gameObject.GetComponent<Renderer>().material.color = Color.red;
		
		// This tells the coroutine to wait here for 1 seconds
		yield return new WaitForSeconds(.1f);
		
		// This code runs after the timer expires
		gameObject.GetComponent<Renderer>().material.color = currentColor;
	}
	private IEnumerator Die(float t) {

		// Run this code before we start the timer
		this.transform.Rotate(-75, 0, 0);
		
		// This tells the coroutine to wait here for x seconds
		yield return new WaitForSeconds(t);
		
		// This code runs after the timer expires
		Destroy(this.gameObject);
	}
}
