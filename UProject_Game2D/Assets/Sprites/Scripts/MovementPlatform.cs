using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour {

	private bool isGoingUp;
	private bool isGoingDown;
	private int platformY;

	// Use this for initialization
	void Start () {
		isGoingUp = true;
		isGoingDown = false;
		platformY = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (isGoingUp) {
			if (platformY <= 60) {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
				platformY += 1;
			} else {
				isGoingUp = false;
				isGoingDown = true;
			}
		} else if (isGoingDown) {
			if (platformY >= 0) {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
				platformY -= 1;
			} else {
				isGoingUp = true;
				isGoingDown = false;
			}
		}
	}
	
}
