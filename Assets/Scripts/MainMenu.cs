using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame() {
		Application.LoadLevel("InGame");
	}

	public void Update() {
		if (Input.GetKey(KeyCode.Return)) {
			StartGame();
		}
	}
}
