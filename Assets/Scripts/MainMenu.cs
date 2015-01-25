using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public AudioSource audio;
	public AudioClip clip;
	
	public Component src;
	public bool playing = false;

	public void StartGame() {
		audio.PlayOneShot(clip);
		src.SendMessage("AudioPlay");
	}
	
	IEnumerator Example() {
        yield return new WaitForSeconds(5);
    }

	public void Update() {
		if (Input.GetKey(KeyCode.Return) && !playing) {
			StartGame();
			playing = true;
		}
	}
}
