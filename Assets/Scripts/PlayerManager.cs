using UnityEngine;

public class PlayerManager : MonoBehaviour {
	[System.Serializable] public class Player {
		public GameObject character;
		public GameObject icon;
	}
	
	public Player player1;
	public Player player2;
	

	public bool running = false;
	public float distance = 3000;
	public bool end = false;
	
	void FixedUpdate() {
		var P1 = player1.character.GetComponent<PlayerController>();
		var P2 = player2.character.GetComponent<PlayerController>();
		
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
		
		//VocalDown();
		
		MiniMove(P1.speed, P2.speed);
		
		
		
		//Hurt();
	}
	
	void MiniMove(float P1Speed, float P2Speed) {
		Vector3 miniP1Pos = player1.icon.transform.position;
		Vector3 miniP2Pos = player2.icon.transform.position;
		
		miniP1Pos.x += ((300 * (P1Speed / 10)) / distance);
		miniP2Pos.x -= ((300 * (P2Speed / 10)) / distance);
		
		player1.icon.transform.position = miniP1Pos;
		player2.icon.transform.position = miniP2Pos;
		
		if (!end) {
			Vector2 a = new Vector2(player1.icon.transform.position.x, player1.icon.transform.position.y);
			Vector2 b = new Vector2(player2.icon.transform.position.x, player2.icon.transform.position.y);
			
			if (Vector2.Distance(a, b) < 50) {
				if (P1Speed > P2Speed) {
					GameManager.instance.Player1();
				} else {
					GameManager.instance.Player2();
				}
				
				Application.LoadLevel("Decision");
				end = true;
			}
		}
	}
}
