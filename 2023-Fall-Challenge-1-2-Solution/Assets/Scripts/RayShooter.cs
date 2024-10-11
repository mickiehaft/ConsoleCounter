using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	private Camera cam;
	[SerializeField] GameObject fireballPrefab;
	[SerializeField] GameObject bouncyBallPrefab;
	void Start() {
		cam = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = cam.pixelWidth/2 - size/4;
		float posY = cam.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
			Ray ray = cam.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit(1);
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			// Instantiate a fireball
			ShootFireball();
		}
		if (Input.GetMouseButtonDown(2)) {
			// Instantiate a bouncy ball
			ShootBouncyBall();
		}
	}

	void ShootFireball() {
		GameObject fireball;
		fireball = Instantiate(fireballPrefab) as GameObject;
		fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
		fireball.transform.rotation = transform.rotation;
		fireball.GetComponent<Rigidbody>().velocity = transform.forward * 10;
	}

	void ShootBouncyBall() {
		Debug.Log("Shooting bouncy ball");
		GameObject bouncyBall;
		bouncyBall = Instantiate(bouncyBallPrefab) as GameObject; //<-- Do I need this "as GameObject"?
		bouncyBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
		bouncyBall.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		// At the raycast hit point, which is passed as an argument to this method, create a sphere
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.GetComponent<Renderer>().material.color = Color.blue;
		
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}