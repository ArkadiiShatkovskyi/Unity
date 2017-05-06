 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {

	private GameController settingsScript;

	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.Find ("Canvas");
		settingsScript = canvas.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log ("Here");
			gameObject.SetActive (false);
			settingsScript.points += 1;
			settingsScript.safeData ();
		}
	}
}
