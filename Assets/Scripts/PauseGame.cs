using UnityEngine;

public class PauseGame : MonoBehaviour {
	[SerializeField] private GameObject pauseScreen;
	
	private float lastTimeScale;
	
	private void Update() {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			if (Time.timeScale == 0) {
				pauseScreen.SetActive(false);
				Time.timeScale = lastTimeScale;
			} else {
				pauseScreen.SetActive(true);
				lastTimeScale = Time.timeScale;
				Time.timeScale = 0;
			}
		}
		
		if (Time.timeScale == 0 && Input.GetKey(KeyCode.Return)) {
			Debug.Log("Quit game");
			Application.Quit();
		}
	}
}
