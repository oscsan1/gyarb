using UnityEngine;
using System.Collections;


public class controller: MonoBehaviour {
	public bool grounded = false;
	public float maxSpeed = 10f;
	public float jumpForce=700f;
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, -25.0F, 0);
	}


	// Update is called once per frame
	void FixedUpdate(){


		float move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody>().velocity.y);
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			GetComponent<Rigidbody>().AddForce(new Vector2(0,jumpForce));
			
				}
		

	}
}