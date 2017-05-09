using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControllerScript : MonoBehaviour {

	public float maxSpeed=10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce=100f;
	public GameObject kunaj;
	public AudioSource audioSorce;
	public AudioClip audioClip;
	private Rigidbody2D rb2d; //rigidbody
	private float volume=1;
	Animator anim;
	bool facingRight=true;
	bool grounded=false;
	float groundRadius=0.2f;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		audioSorce = gameObject.GetComponent<AudioSource> ();
		//kunaj = GameObject.FindGameObjectWithTag ("kunaj");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rb2d.velocity.y);

		if (grounded && Input.GetKeyUp (KeyCode.Mouse0)) {
			anim.SetBool ("Throw", true);
		}

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb2d.velocity = new Vector2 (move * maxSpeed,rb2d.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update(){
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false);
			rb2d.AddForce (new Vector2 (0, jumpForce));
		}

		if (grounded && Input.GetKeyUp (KeyCode.Mouse0)) {
			float direction = facingRight ? 1 : -1;
			Vector2 position = new Vector2 (facingRight?gameObject.transform.position.x+3:gameObject.transform.position.x-3, gameObject.transform.position.y);
			GameObject gb= Instantiate (kunaj, position, Quaternion.identity);
			Rigidbody2D rg = gb.GetComponent<Rigidbody2D> ();
			gb.transform.localScale =new Vector3(direction * gb.transform.localScale.x,1,1);

			rg.AddForce (new Vector2(direction * 2000f, 0));
			audioSorce.PlayOneShot (audioClip);
			anim.SetBool ("Throw", false);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnGUI(){
		//Debug.Log ("HELLO!");
		volume = GUI.HorizontalSlider (new Rect (800, 30, 100, 100),volume,0,1);
		audioSorce.volume = volume;
	}
}
