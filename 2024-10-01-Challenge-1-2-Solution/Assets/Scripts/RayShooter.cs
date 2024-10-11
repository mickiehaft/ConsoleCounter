using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	private Camera cam;
	public GameObject bouncyBallPrefab;
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
				// Is there a ReactiveTarget script attached to the object?
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>(); 
				if (target != null) {
					target.ReactToHit();
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}

		// If the right mouse button is clicked, Instantiate a projectile that bounces
		if (Input.GetMouseButtonDown(1)) {
			GameObject bouncyBall = Instantiate(bouncyBallPrefab) as GameObject;
			// Put the ball 1.5 units in front of "me"
			bouncyBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
			
			Rigidbody rb = bouncyBall.GetComponent<Rigidbody>(); // Gets a reference to the attached Rigidbody component
			rb.AddForce(transform.forward * 1000);
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}