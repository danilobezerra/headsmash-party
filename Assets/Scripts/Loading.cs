using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	public Text text;

	public void StartGame() {
		Application.LoadLevel("InGame");
	}

	public float counter = 7;


	public void FixedUpdate() {

		counter -= Time.deltaTime;

		if (counter <= 4) {
		int counter2 = (int)counter;
		text.text = counter2.ToString();
		}

		if (counter <= 0) {
			StartGame();
		}
	}
}
