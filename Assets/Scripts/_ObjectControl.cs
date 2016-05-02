using UnityEngine;

public class _ObjectControl : MonoBehaviour {
	[SerializeField] private float _velocity;
	
	private SpriteRenderer spriteRenderer;
	
	public float velocity {
		get { return _velocity; }
		set { _velocity = value; }
	}
	
	public bool flip {
		get { return spriteRenderer.flipX; }
		set { spriteRenderer.flipX = value; }
	}
	
	private void Awake() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	private void Update() {
		Vector2 translation = !spriteRenderer.flipX ? Vector2.left : Vector2.right;
		transform.Translate(translation * _velocity * Time.deltaTime);
	}
	
	private void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
