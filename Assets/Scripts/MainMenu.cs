using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public AudioSource _audio;
	public AudioClip clip;
	
	public bool playing = false;
	
	public float seconds = 0;
	public string loadLevelName;

	public void StartGame() {
		_audio.PlayOneShot(clip);
		StartCoroutine(AudioPlay());
	}
	
	IEnumerator AudioPlay() {
		yield return new WaitForSeconds(seconds);
		Application.LoadLevel(loadLevelName);
	}

	public void Update() {
		if (Input.GetKey(KeyCode.Return) && !playing) {
			StartGame();
			playing = true;
		}
	}
}
