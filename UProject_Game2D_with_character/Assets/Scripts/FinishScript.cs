using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

	private GameController settingsScript;

	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.Find ("Canvas");;
		settingsScript = canvas.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (gameObject.tag == "finish1" && other.tag=="Player") {
			//Debug.Log ("Finish 1!");
			settingsScript.safeData ();
			//SceneManager.LoadScene ("scene2");
		}else if(gameObject.tag == "finish2" && other.tag=="Player"){
			//SceneManager.LoadScene ("menu");
		}
	}
}
