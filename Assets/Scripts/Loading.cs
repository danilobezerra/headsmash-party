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
		text.text = counter2 == 0 ? "SMASH!" : counter2.ToString();
		Debug.Log("counter: " + counter + " - counter2: " + counter2);
		}

		if (counter <= 0) {
			StartGame();
		}
		
		
		
	}
	
}
