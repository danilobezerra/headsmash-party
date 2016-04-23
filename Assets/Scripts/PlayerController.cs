using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[System.Serializable] public class PlayerPosition {
		public Transform top;
		public Transform middle;
		public Transform bottom;
	}
	
	public AudioClip[] hits;

	private int tier;
	
	public bool hurt = false;
	public bool red = false;
	public bool hit = false;
	public LayerMask enemyMask;
	public float hitSlow = 0.9f;
	public float hurtDelay = 0.2f;
	public float speed = 10;
	public bool running = false;
	
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private PlayerPosition playerPosition;
	[SerializeField] private string yAxisName;
	
	private SpriteRenderer spriteRenderer;

	private void Awake() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}


	// Use this for initialization
	void Start() {
		tier = 0;
	}
	
	// Update is called once per frame
	void Update() {
		InputMovement();
		
		/*if (running){
			P1Speed += ((50 - P1Speed) / 2000);
			P2Speed += ((50 - P2Speed) / 2000);
			distance -= (P1Speed + P2Speed) / 10;
			if (distance <= 0) {
				// load level
			}
		}*/
		
		Hit();
	}
	
	
	private void InputMovement() {
		if (Input.GetButtonDown(yAxisName) && Input.GetAxisRaw(yAxisName) > 0) {
			Vector2 newPosition = transform.position;
			
			switch(tier) {
			case 0:
				newPosition.y = playerPosition.top.position.y;
				tier = 1;
				break;
			case 1:
				tier = 1;
				break;
			case 2:
				newPosition.y = playerPosition.middle.position.y;
				tier = 0;
				break;
			}
			
			transform.position = newPosition;
		}
		
		if (Input.GetButtonDown(yAxisName) && Input.GetAxisRaw(yAxisName) < 0) {
			Vector2 newPosition = transform.position;
			
			switch(tier) {
			case 0:
				newPosition.y = playerPosition.bottom.position.y;
				tier = 2;
				break;
			case 1:
				newPosition.y = playerPosition.middle.position.y;
				tier = 0;
				break;
			case 2:
				tier = 2;
				break;
			}
				
			transform.position = newPosition;
		}
	}
	
	private void Hit() {
		if (!hit) {
			Vector2 p1PosA = new Vector2(0, 0);
			p1PosA.x = transform.position.x - 0.7f;
			p1PosA.y = transform.position.y + 1;
			
			Vector2 p1PosB = new Vector2(0, 0);
			p1PosB.x = transform.position.x + 0.7f;
			p1PosB.y = transform.position.y - 1;
			
			Collider2D[] hits1 = Physics2D.OverlapAreaAll(p1PosA, p1PosB, enemyMask);
			if (hits1.Length >= 1) {
				hit = true;
				speed *= hitSlow;
				StartCoroutine(Hurt());
			}
		}
		
		if (speed < 10) {
			speed = 10;
		}
		
		FlashingRed();
	}
	
	private IEnumerator Hurt() {
		audioSource.PlayOneShot(hits[Random.Range(0, hits.Length)]);
		hurt = true;
		
		yield return new WaitForSeconds(hurtDelay);
		
		spriteRenderer.color = Color.white;
		hurt = false;
		hit = false;
	}
	private void FlashingRed() {
		if (hurt) {
			if (!red) {
				spriteRenderer.color = Color.red;
				red = true;
			} else {
				spriteRenderer.color = Color.white;
				red = false;
			}
		}
	}
	
	
}
