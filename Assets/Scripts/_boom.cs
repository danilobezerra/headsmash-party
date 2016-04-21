using UnityEngine;

public class _boom : MonoBehaviour {
	public bool up = false;
	public bool playing = false;

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
