using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame() {
		Application.LoadLevel("Loading");
	}

	public void Update() {
		if (Input.GetKey(KeyCode.Return)) {
			StartGame();
		}
	}
}
