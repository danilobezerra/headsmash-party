using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Celebration : MonoBehaviour {

	public Text scoreP1;
	public Text scoreP2;


	void Start()
		{
		scoreP1.text = "Score P1";
		scoreP2.text = "Score P2";
		}

	public void StartGame() {
		Application.LoadLevel("Loading");

	}
	
	public void Update() {
		if (Input.GetKey(KeyCode.Return)) {
			StartGame();
		}



	}
}
