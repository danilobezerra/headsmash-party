using UnityEngine;

public class PauseGame : MonoBehaviour {
	[SerializeField] private GameObject pauseScreen;
	[SerializeField] private string cancelKey;
	[SerializeField] private string submitKey;
	
	private float lastTimeScale;
	
	private void Update() {
		if (Input.GetButtonDown(cancelKey)) {
			if (Time.timeScale == 0) {
				pauseScreen.SetActive(false);
				Time.timeScale = lastTimeScale;
			} else {
				pauseScreen.SetActive(true);
				lastTimeScale = Time.timeScale;
				Time.timeScale = 0;
			}
		}
		
		if (Time.timeScale == 0 && Input.GetButtonDown(submitKey)) {
			Debug.Log("Quit game");
			Application.Quit();
		}
	}
}
