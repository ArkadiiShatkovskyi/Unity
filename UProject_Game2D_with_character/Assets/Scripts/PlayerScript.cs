using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerScript : MonoBehaviour {

	public Rigidbody2D rigidbody;
	public Platformer2DUserControl userControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("enemy")) {
			StartCoroutine (haltMove ());
			rigidbody.velocity = (gameObject.transform.position - other.gameObject.transform.position).normalized * 20;
		} else if (other.gameObject.CompareTag ("springboard")) {
			StartCoroutine (haltMove ());
			rigidbody.velocity = new Vector2(-10f,10f).normalized * 150;
		} else if (other.gameObject.CompareTag ("springboardL")) {
			StartCoroutine (haltMove ());
			rigidbody.velocity = new Vector2(10f,15f).normalized * 50;
		} else if (other.gameObject.CompareTag ("springboardR")) {
			StartCoroutine (haltMove ());
			rigidbody.velocity = new Vector2(-10f,15f).normalized * 50;
		}
	}

	IEnumerator haltMove(){
		userControl.controlEnable = false;
		yield return new WaitForSeconds (0.5f);
		userControl.controlEnable = true;
	}
}
