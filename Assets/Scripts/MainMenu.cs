using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void NewGame() {
		Application.LoadLevel("InGame");
	}

	public void Options() {

	}

	public void Credits() {

	}
	
	public void Exit() {
		if (!Application.isWebPlayer) Application.Quit();
	}
}
