using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public int points;
	public int hp;
	public static GameData controller;
	private Text text_points;
	private GameObject[] lifes;

	// Use this for initialization
	void Start () {

		text_points =GameObject.FindGameObjectWithTag ("points").GetComponent<Text>();
		text_points.text="Points: "+points;

		controller = GameObject.FindGameObjectWithTag ("gameData").GetComponent<GameData>();

		if (gameObject.tag == "canvas1") {
			points = 0;
			hp = 2;
			showLifes (hp);
		} else {
			points = controller.points;
			hp = controller.hp;
			showLifes (hp);
		}
	}

	public void safeData(){
		controller.hp=hp;
		controller.points = points;
	}

	public void showLifes(int n){
		lifes = new GameObject[3];

		for (int i = 0; i < 3; i++) {
			lifes[i]= GameObject.FindGameObjectWithTag ("life"+(i+1));
			lifes [i].SetActive (false);
		}

		for (int i = 0; i <= n; i++) {
			lifes [i].SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {
		text_points.text="Points: "+points;
	}

	public void minusLife(){
		if (hp >= 1) {
			lifes [hp].SetActive (false);
			hp--;
		} else if(hp==0) {
			lifes [hp].SetActive (false);
			//SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
			SceneManager.LoadScene("menu");
		}
	}
}
