using UnityEngine;
using System.Collections;


public class controller: MonoBehaviour {
	public Renderer rend;
	public Vector3 velocity;
	public Rigidbody rb;
	public float maxSpeed = 10f;
	public float jumpForce=1f;
	public bool grounded=false;
	public Transform groundCheck;
	public float groundRadius=.2f;
	public LayerMask whatIsGround;
	public bool doubleJump=false;
	public Collision collision;
	public float move;
	AudioSource audio1;
	AudioSource audio2;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Physics.gravity = new Vector3(0, -25.0F, 0);
		rend = GetComponent<Renderer> ();
		AudioSource[] audios = GetComponents<AudioSource> ();
		audio1 = audios [0];
		audio2 = audios [1];
	}



	// Update is called once per frame
	void FixedUpdate(){
		

		if (grounded) {
			doubleJump = false;
		}
		float move=Input.GetAxis("Horizontal");
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);


	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			grounded = true;
			audio1.mute = true;
			audio2.mute = false;
		}
			
		
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Water")) {

			audio1.mute = false;
			audio2.mute = true;
		}
	}
	void OnCollisionExit(Collision collision)
	{
		grounded = false;
	}
	void Update(){
		
		if ((grounded ||!doubleJump)&& Input.GetKeyDown (KeyCode.Space)) {
			rb.velocity = new Vector3 (move * maxSpeed, 0f);
			rb.AddForce(new Vector2(0, jumpForce));
			if (!doubleJump&&!grounded) {
				doubleJump = true;
				grounded = false;
			}
		}
	}

}