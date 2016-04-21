using UnityEngine;

public class _fadeOut : MonoBehaviour {
	SpriteRenderer rend;

	void Start() {
		rend = transform.GetComponent<SpriteRenderer>();
	}

	void FixedUpdate() {
		if (rend.color.a > 0) {
			Color color = rend.color;
			color.a -= 0.01f;
			rend.color = color;
		}
	}
}
