using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

	private bool isGoingLeft;
	private int position;
	public float speed;

	private GameController settingsScript;

	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.Find ("Canvas");;
		settingsScript = canvas.GetComponent<GameController> ();
		isGoingLeft = true;
		position = 0;
		//speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (isGoingLeft) {
			if (position <= 25) {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
				position += 1;
			}else{
				isGoingLeft = false;
			}
		} else {
			if (position >= -25) {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
				position -= 1;
			} else {
				isGoingLeft = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			settingsScript.minusLife ();
		}
	}
		
}
