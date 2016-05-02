using UnityEngine;

public class _bgControl : MonoBehaviour {
	public Vector3 inicialPos;
	public Vector3 finalPos;

	public float speed = 10;
	public bool dirRight = false;

	public GameObject other;

	void FixedUpdate() {
		Vector3 dir = new Vector3(1, 0, 0);
		if (!dirRight) {
			dir.x = -1;
		}
		
		transform.Translate(dir * speed * Time.deltaTime);
		
		if (dirRight) {
			if (gameObject.transform.position.x >= finalPos.x) {
				gameObject.transform.position = inicialPos;
				
				Vector3 otherPos = other.transform.position;
				otherPos.x = 20;
				
				other.transform.position = otherPos;
			}
		} else {
			if (gameObject.transform.position.x <= finalPos.x) {
				gameObject.transform.position = inicialPos;
				
				Vector3 otherPos = other.transform.position;
				otherPos.x = -20;
				
				other.transform.position = otherPos;
			}
		}
	}
}
