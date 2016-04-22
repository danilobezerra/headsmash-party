using UnityEngine;

public class CameraShake : MonoBehaviour {
	[RangeAttribute(0, .1f)] [SerializeField] private float yDisplacement;

	private void FixedUpdate() {
		Vector3 cameraPosition = transform.position;
		
		if (cameraPosition.y == 0) {
			cameraPosition.y += yDisplacement;
			transform.position = cameraPosition;
		} else {
			cameraPosition.y -= yDisplacement;
			transform.position = cameraPosition;
		}
	}
}
