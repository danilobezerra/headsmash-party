#pragma strict

public var player1 : GameObject;
public var player2 : GameObject;
public var P1Speed : float = 10;
public var P2Speed : float = 10;
public var running : boolean = false;
public var p1hit : boolean = false;
public var p2hit : boolean = false;
public var enemyMask : LayerMask;
public var hitSlow : float = 0.9;
public var hurtDelay : float = 0.2;

public var distance : int = 100000;

function Start(){
	partyRules();
}

function FixedUpdate() {
	if (running){
		P1Speed += ((50 - P1Speed)/2000);
		P2Speed += ((50 - P2Speed)/2000);
		distance -= (P1Speed + P2Speed)/10;
		Debug.Log(distance);
		if (distance <= 0){
			Debug.Log("FINISH");
		}
	}
	
	if (!p1hit){
		var p1PosA : Vector2 = Vector2(0,0);
		p1PosA.x = player1.transform.position.x - 0.7;
		p1PosA.y = player1.transform.position.y + 1;
		var p1PosB : Vector2 = Vector2(0,0);
		p1PosB.x = player1.transform.position.x + 0.7;
		p1PosB.y = player1.transform.position.y - 1;
		
		var hits1 : Collider2D[] = Physics2D.OverlapAreaAll(p1PosA,p1PosB,enemyMask);
		if (hits1.Length >= 1){
			p1hit = true;
			P1Speed *= hitSlow;
			P1Hurt();
		}
	}
	
	if (!p2hit){
		var p2PosA : Vector2 = Vector2(0,0);
		p2PosA.x = player2.transform.position.x - 0.7;
		p2PosA.y = player2.transform.position.y + 1;
		var p2PosB : Vector2 = Vector2(0,0);
		p2PosB.x = player2.transform.position.x + 0.7;
		p2PosB.y = player2.transform.position.y - 1;

		var hits2 : Collider2D[] = Physics2D.OverlapAreaAll(p2PosA,p2PosB,enemyMask);
		if (hits2.Length >= 1){
			p2hit = true;
			P2Speed *= hitSlow;
			P2Hurt();
		}
	}
	if (P1Speed < 10){
		P1Speed = 10;
	}
	if (P2Speed < 10){
		P2Speed = 10;
	}
	
	Debug.Log("Player1: " + P1Speed + " - Player2: " + P2Speed);
}


function P1Hurt(){
	yield WaitForSeconds (hurtDelay);
	p1hit = false;
}

function P2Hurt(){
	yield WaitForSeconds (hurtDelay);
	p2hit = false;
}

function partyRules(){
	yield WaitForSeconds (5);
	
}