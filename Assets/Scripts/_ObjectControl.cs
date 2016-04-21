using UnityEngine;

public class _ObjectControl : MonoBehaviour {
	public float speed = 10;
	public bool dirRight  = false;

	void FixedUpdate() {
		Vector3 dir = new Vector3(1, 0, 0);
		if (!dirRight) {
			dir.x = -1;
		}
		
		transform.Translate(dir * speed * Time.deltaTime);
	}
	
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
