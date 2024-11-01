using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    //declare variables
        public float speed = 9f;
        public float jump = 8f;

        private BoxCollider2D box;
        private Rigidbody2D body;
        private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        /*code that allows this script to affect the 
        rigidbody and animator for our sprite*/
        box = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //code for moving left and right
        float deltaX = Input.GetAxis("Horizontal") * speed; 

        Vector2 movement = new Vector2(deltaX, body.velocity.y);

        body.velocity = movement;

        //code to flip the direction of character
            
        anim.SetFloat("speed", Mathf.Abs(deltaX));

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }

        //code for the entirety of jumping

            //checking if the player is on the ground

        Vector3 max = box.bounds.max;
		Vector3 min = box.bounds.min;
		Vector2 corner1 = new Vector2(max.x, min.y - .1f);
		Vector2 corner2 = new Vector2(min.x, min.y - .2f);
		Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

		bool grounded = false;
        
            //code to swap between jump animation and walk/idle
		if (hit != null)
        {
			grounded = true;
			anim.SetBool("grounded", true);
		} else if (hit == null)
        {
			anim.SetBool("grounded", false);
		} 
        
        	//jumping code 
		if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
			body.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
}
