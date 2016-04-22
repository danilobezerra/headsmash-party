using UnityEngine;
using System.Collections;

public class _PlayerStats : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public float P1Speed = 10;
	public float P2Speed = 10;
	public bool running = false;
	public bool p1hit = false;
	public bool p2hit = false;
	public LayerMask enemyMask;
	public float hitSlow = 0.9f;
	public float hurtDelay = 0.2f;
	
	public float distance = 3000;

	public GameObject vocalist;
	public bool vocalDown;
	public int vDir;
	
	public float spaceMulti = 0;
	public GameObject newIcon1;
	public GameObject newIcon2;
	public GameObject[] icon;
	public bool iconMove = false;
	public AudioClip[] vocalIcon;
	
	public bool match = false;
	public int iconPlayed;

	public GameObject miniP1;
	public GameObject miniP2;
	public GameObject decision;
	public bool end = false;
	

	public bool p1Hurt = false;
	public bool p1Red = false;

	public bool p2Hurt = false;
	public bool p2Red = false;

	IEnumerator Start() {
		iconPlayed = -1;
		
		yield return new WaitForSeconds(6);
		StartCoroutine(partyRules());
		
		yield return new WaitForSeconds(8);
		StartCoroutine(partyRules());
	}
	
	void FixedUpdate() {
		if (running){
			P1Speed += ((50 - P1Speed) / 2000);
			P2Speed += ((50 - P2Speed) / 2000);
			distance -= (P1Speed + P2Speed) / 10;
			if (distance <= 0) {
				// load level
			}
		}
		
		if (!p1hit) {
			Vector2 p1PosA = new Vector2(0, 0);
			p1PosA.x = player1.transform.position.x - 0.7f;
			p1PosA.y = player1.transform.position.y + 1;
			
			Vector2 p1PosB = new Vector2(0, 0);
			p1PosB.x = player1.transform.position.x + 0.7f;
			p1PosB.y = player1.transform.position.y - 1;
			
			Collider2D[] hits1 = Physics2D.OverlapAreaAll(p1PosA, p1PosB, enemyMask);
			if (hits1.Length >= 1) {
				p1hit = true;
				P1Speed *= hitSlow;
				StartCoroutine(P1Hurt());
			}
		}
		
		if (!p2hit) {
			Vector2 p2PosA = new Vector2(0, 0);
			p2PosA.x = player2.transform.position.x - 0.7f;
			p2PosA.y = player2.transform.position.y + 1;
			
			Vector2 p2PosB = new Vector2(0, 0);
			p2PosB.x = player2.transform.position.x + 0.7f;
			p2PosB.y = player2.transform.position.y - 1;

			Collider2D[] hits2 = Physics2D.OverlapAreaAll(p2PosA, p2PosB, enemyMask);
			if (hits2.Length >= 1) {
				p2hit = true;
				P2Speed *= hitSlow;
				StartCoroutine(P2Hurt());
			}
		}
		
		if (P1Speed < 10) {
			P1Speed = 10;
		}
		
		if (P2Speed < 10) {
			P2Speed = 10;
		}
		
		if (vocalDown) {
			vocalist.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
			
			if (iconMove) {
				newIcon1.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
				newIcon2.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
			}
			
			if (vocalist.transform.position.y <= 600) {
				vDir = 1;
				vocalDown = false;
			}
		}
		
		Vector3 miniP1Pos = miniP1.transform.position;
		Vector3 miniP2Pos = miniP2.transform.position;
		
		miniP1Pos.x += ((300 * (P1Speed / 10)) / distance);
		miniP2Pos.x -= ((300 * (P2Speed / 10)) / distance);
		
		miniP1.transform.position = miniP1Pos;
		miniP2.transform.position = miniP2Pos;
		
		if (!end) {
			Vector2 a = new Vector2(miniP1.transform.position.x, miniP1.transform.position.y);
			Vector2 b = new Vector2(miniP2.transform.position.x, miniP2.transform.position.y);
			
			if (Vector2.Distance(a, b) < 50) {
				if (P1Speed > P2Speed) {
					_Referee.instance.Player1();
				} else {
					_Referee.instance.Player2();
				}
				
				Application.LoadLevel("Decision");
				end = true;
			}
		}
		
		if (p1Hurt) {
			if (!p1Red) {
				player1.GetComponent<Renderer>().material.color = Color.red;
				p1Red = true;
			} else {
				player1.GetComponent<Renderer>().material.color = Color.white;
				p1Red = false;
			}
		}
		
		if (p2Hurt) {
			if (!p2Red) {
				player2.GetComponent<Renderer>().material.color = Color.red;
				p2Red = true;
			} else {
				player2.GetComponent<Renderer>().material.color = Color.white;
				p2Red = false;
			}
		}
	}
	
	IEnumerator P1Hurt() {
		player1.GetComponent<PlayerMovement>().PlayHurt();
		p1Hurt = true;
		
		yield return new WaitForSeconds(hurtDelay);
		p1Hurt = false;
		
		player1.GetComponent<Renderer>().material.color = Color.white;
		p1hit = false;
	}
	
	IEnumerator P2Hurt() {
		player2.GetComponent<PlayerMovement>().PlayHurt();
		p2Hurt = true;
		
		yield return new WaitForSeconds(hurtDelay);
		p2Hurt = false;
		
		player2.GetComponent<Renderer>().material.color = Color.white;
		p2hit = false;
	}
	
	IEnumerator partyRules() {
		int randIcon = 0;
		
		while (!match) {
			randIcon = Random.Range(0, icon.Length);
			if (randIcon != iconPlayed) {
				match = true;
			}
		}
		
		match = false;
		iconPlayed = randIcon;
		GetComponent<AudioSource>().PlayOneShot(vocalIcon[randIcon]);
		
		newIcon1 = Instantiate(icon[randIcon], vocalist.transform.position, Quaternion.identity) as GameObject;
		newIcon1.transform.parent = vocalist.transform.parent;
		
		Vector3 newIcon1Pos = newIcon1.transform.position;
		newIcon1Pos.x -= 350;
		newIcon1Pos.y -= 550;
		newIcon1Pos.x += spaceMulti;
		newIcon1.transform.position = newIcon1Pos;
		
		newIcon2 = Instantiate(icon[randIcon], vocalist.transform.position, Quaternion.identity) as GameObject;
		newIcon2.transform.parent = vocalist.transform.parent;
		
		Vector3 newIcon2Pos = newIcon2.transform.position;
		newIcon2Pos.x += 200;
		newIcon2Pos.y -= 550;
		newIcon2Pos.x += spaceMulti;
		newIcon2.transform.position = newIcon2Pos;
		
		iconMove = true;
		spaceMulti += 150;
		vDir = -1;
		vocalDown = true;
		yield return new WaitForSeconds(2.3f);
		
		iconMove = false;
		vDir = 1;
		vocalDown = true;
		yield return new WaitForSeconds(2);
		
		vocalDown = false;
		Vector3 vocalistPos = vocalist.transform.position;
		vocalistPos.y = 900;
		vocalist.transform.position = vocalistPos;
	}
}
