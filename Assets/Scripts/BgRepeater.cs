using UnityEngine;
using System.Collections;

public class BgRepeater : MonoBehaviour {
	private Vector3 backPos;
	public float width = 14.22f;
	public float height = 0f;
	private float x;
	private float y;

	/*private Transform cameraTransform;
	private float spriteWidth;
	
	public Camera cam;
	
	void Start() {
		cameraTransform = cam.transform;

		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	void Update() {
		if ((transform.position.x + spriteWidth) < cameraTransform.position.x) {
			  Vector3 newPos = transform.position;
			  newPos.x += 2.0f * spriteWidth; 
			  transform.position = newPos;
		}
	}*/
	
	void OnBecameVisible() {
		backPos = gameObject.transform.position;

		Debug.Log(backPos);
		x = backPos.x + width * 2;
		y = backPos.y + height * 2;
		gameObject.transform.position = new Vector3(x, y, 0f);
	}
}
