using UnityEngine;
using System.Collections;

public class Celebration : MonoBehaviour {
	
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			StartGame();
		}
	}
	
	public void StartGame() {
		Debug.Log("change");
		Application.LoadLevel("Loading");

	}
}
