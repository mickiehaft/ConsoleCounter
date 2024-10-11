using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
	public float gravity = -9.8f;
	public float walkSpeed = 6f;
	public float sprintSpeed = 12f;
	public float crouchSpeed = 3f;
	public float crouchHeight = 1f;
	public KeyCode crouchKey = KeyCode.C;
public float zoomFOV = 30f; // Adjust this value to set the desired zoom FOV
    public float zoomSpeed = 5f; // Adjust this value to set the zoom transition speed

	// "private" access-control keyword used because these variables are managed internally to the script
	// i.e. they don't need to be accessed by other scripts or edited in the inspector (and actually it's very
	// important that they not be!)
	private float speed;
	private bool crouching;
	private float originalHeight;
	private Vector3 originalCenter;
	private CharacterController charController;
	private Camera playerCamera;
	private Vector3 originalCameraPosition;
    private float originalFOV;

	void Start()
	{
		charController = GetComponent<CharacterController>();
		originalHeight = charController.height;
		originalCenter = charController.center;
		playerCamera = Camera.main;
        originalFOV = playerCamera.fieldOfView;
		originalCameraPosition = playerCamera.transform.localPosition;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			crouching = false;
			speed = sprintSpeed;
		}
		else if (Input.GetKey(crouchKey))
		{	
			crouching = true;
			speed = crouchSpeed;
		}
		else
		{
			crouching = false;
			speed = walkSpeed;
		}

		if (crouching)
		{
			// Crouch down
			charController.height = crouchHeight;
			charController.center = new Vector3(originalCenter.x, originalCenter.y * crouchHeight / originalHeight, originalCenter.z);
		}
		else
		{
			// Stand up
			charController.height = originalHeight;
			charController.center = originalCenter;
		}

		// if (Input.GetMouseButton(1))
        // {
        //     // Zoom in
        //     playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        // }
        // else
        // {
        //     // Zoom out
        //     playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, originalFOV, zoomSpeed * Time.deltaTime);
        // }

		
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);
	}
}
