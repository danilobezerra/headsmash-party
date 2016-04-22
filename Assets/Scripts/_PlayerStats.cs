using UnityEngine;
using System.Collections;

public class _PlayerStats : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	public bool running = false;
	public bool p1hit = false;
	public bool p2hit = false;
	public LayerMask enemyMask;
	public float hitSlow = 0.9f;
	public float hurtDelay = 0.2f;
	
	public float distance = 3000;

	public VocalistController vocalist;
	//public GameObject vocalist;
	//public bool vocalDown;
	//public int vDir;
	
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

	/*IEnumerator Start() {
		iconPlayed = -1;
		
		yield return new WaitForSeconds(6);
		StartCoroutine(partyRules());
		
		yield return new WaitForSeconds(8);
		StartCoroutine(partyRules());
	}*/
	
	void FixedUpdate() {
		var P1 = player1.GetComponent<PlayerMovement>();
		var P2 = player2.GetComponent<PlayerMovement>();
		
		if (running){
			P1.speed += ((50 - P1.speed) / 2000);
			
			P2.speed += ((50 - P2.speed) / 2000);
			
			distance -= (P1.speed + P2.speed) / 10;
			if (distance <= 0) {
				// load level
			}
		}
		
		//Hit();
		
		if (P1.speed < 10) {
			P1.speed = 10;
		}
		
		if (P2.speed < 10) {
			P2.speed = 10;
		}
		
		VocalDown();
		
		MiniMove(P1.speed, P2.speed);
		
		
		
		//Hurt();
	}
	
	void VocalDown() {
		//if (vocalist.vocalDown) {
			//vocalist.transform.Translate(new Vector2(0, vDir) * 400 * Time.deltaTime);
			
			//if (iconMove) {
			//	newIcon1.transform.Translate(new Vector2(0, vocalist.vDir) * 400 * Time.deltaTime);
			//	newIcon2.transform.Translate(new Vector2(0, vocalist.vDir) * 400 * Time.deltaTime);
			//}
			
			//if (vocalist.transform.position.y <= 600) {
			//	vDir = 1;
			//	vocalDown = false;
			//}
		//}
	}
	
	void MiniMove(float P1Speed, float P2Speed) {
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
		//vocalist.vDir = -1;
		//vocalist.vocalDown = true;
		yield return new WaitForSeconds(2.3f);
		
		iconMove = false;
		//vocalist.vDir = 1;
		//vocalist.vocalDown = true;
		yield return new WaitForSeconds(2);
		
		//vocalist.vocalDown = false;
		//Vector3 vocalistPos = vocalist.vocalist.transform.position;
		//vocalistPos.y = 100;
		//vocalist.vocalist.transform.position = vocalistPos;
	}
}
