using UnityEngine;

public class _boom : MonoBehaviour {
	bool up = false;
	bool playing = false;

	void FixedUpdate() {
		if (!playing) {
			GetComponent<AudioSource>().Play();
			playing = true;
		}
		
		Vector3 pos = transform.position;
		if (!up) {
			pos.y += 0.1f;
			transform.position = pos;
			up = true;
		} else {
			pos.y -= 0.1f;
			transform.position = pos;
			up = false;
		}
	}
}
