using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuListenerScript : MonoBehaviour {

	public static GameData gameData;

	// Use this for initialization
	void Start () {
		Button buttonExit = GameObject.FindGameObjectWithTag ("btnExit").GetComponent<Button> ();
		buttonExit.onClick.AddListener(delegate { exit (); }); 
		Button buttonRestart = GameObject.FindGameObjectWithTag ("btnRestart").GetComponent<Button> ();
		buttonRestart.onClick.AddListener(delegate { restart (); });
		gameData=GameObject.FindGameObjectWithTag ("gameData").GetComponent<GameData>();
		Text text = GameObject.FindGameObjectWithTag ("result").GetComponent<Text> ();
		text.text = "Your points: " + gameData.points;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restart (){
		SceneManager.LoadScene ("scene");
	}

	public void exit(){
		Application.Quit ();
	}
}
