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

public var distance : float = 3000;

public var vocalist : GameObject;
public var vocalDown : boolean;
public var vDir : int;

public var spaceMulti : float = 0;
public var newIcon1 : GameObject;
public var newIcon2 : GameObject;
public var icon : GameObject[];
public var iconMove : boolean = false;

public var match : boolean = false;
public var iconPlayed : int;

public var miniP1 : GameObject;
public var miniP2 : GameObject;
public var decision : GameObject;
public var end : boolean = false;

public var ref : Referee;

public var p1Hurt : boolean = false;
public var p1Red : boolean = false;

public var p2Hurt : boolean = false;
public var p2Red : boolean = false;

public var pause : GameObject;
public var pauseScreen : GameObject;
public var paused : boolean = false;
public var lastTime : float = 0;


function Start(){
	iconPlayed = -1;
	yield WaitForSeconds(6);
	partyRules();
	yield WaitForSeconds(8);
	partyRules();
	var newReferee = GameObject.Find("Ref");
	ref = newReferee.GetComponent("Referee");
}


function Update(){
	if (Input.GetKeyUp(KeyCode.Escape) && !paused) {
		pause = Instantiate(pauseScreen, Vector3.zero, Quaternion.identity);
		pause.transform.parent = vocalist.transform.parent;
		pause.transform.position.x += 540;
		pause.transform.position.y += 320;
		paused = true;
		lastTime = Time.timeScale;
		Time.timeScale = 0;
	}else if (Input.GetKeyUp(KeyCode.Escape) && paused){
		Destroy(pause);
		Time.timeScale = lastTime;
		paused = false;
	}
	
	if (paused && Input.GetKey(KeyCode.Return)){
		Application.Quit();
	}
}


function FixedUpdate() {
	if (running){
		P1Speed += ((50 - P1Speed)/2000);
		P2Speed += ((50 - P2Speed)/2000);
		distance -= (P1Speed + P2Speed)/10;
		if (distance <= 0){
			//load level
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
		
	if(vocalDown){
		vocalist.transform.Translate(Vector2(0,vDir) * 400 * Time.deltaTime);
		if (iconMove){
			newIcon1.transform.Translate(Vector2(0,vDir) * 400 * Time.deltaTime);
			newIcon2.transform.Translate(Vector2(0,vDir) * 400 * Time.deltaTime);
		}
		if (vocalist.transform.position.y <= 500){
			vDir = 1;
			vocalDown = false;
		}
	}
	
	miniP1.transform.position.x += ((300*(P1Speed/10))/distance);
	miniP2.transform.position.x -= ((300*(P2Speed/10))/distance);
	if (!end){
		if (Vector2.Distance(Vector2(miniP1.transform.position.x,miniP1.transform.position.y),Vector2(miniP2.transform.position.x,miniP2.transform.position.y)) < 50){
			if (P1Speed > P2Speed){
				ref.Player1();
			}else{
				ref.Player2();
			}
			Application.LoadLevel ("Decision");
			end = true;
		}
	}
	
	if (p1Hurt){
		if (!p1Red){
			player1.renderer.material.color = Color.red;
			p1Red = true;
		}else{
			player1.renderer.material.color = Color.white;
			p1Red = false;
		}
	}
	
	
	if (p2Hurt){
		if (!p2Red){
			player2.renderer.material.color = Color.red;
			p2Red = true;
		}else{
			player2.renderer.material.color = Color.white;
			p2Red = false;
		}
	}
}


function P1Hurt(){
	player1.SendMessage("PlayHurt");
	p1Hurt = true;
	yield WaitForSeconds(hurtDelay);
	p1Hurt = false;
	player1.renderer.material.color = Color.white;
	p1hit = false;
}


function P2Hurt(){
	player2.SendMessage("PlayHurt");
	p2Hurt = true;
	yield WaitForSeconds(hurtDelay);
	p2Hurt = false;
	player2.renderer.material.color = Color.white;
	p2hit = false;
}


function partyRules(){
	while (!match){
		var randIcon : int = Random.Range(0,icon.Length);
		if (randIcon != iconPlayed){
			match = true;
		}
	}
	match = false;
	iconPlayed = randIcon;
	newIcon1 = Instantiate(icon[randIcon], vocalist.transform.position, Quaternion.identity);
	newIcon1.transform.parent = vocalist.transform.parent;
	newIcon1.transform.position.x -= 350;
	newIcon1.transform.position.y -= 450;
	newIcon1.transform.position.x += spaceMulti;
	
	newIcon2 = Instantiate(icon[randIcon], vocalist.transform.position, Quaternion.identity);
	newIcon2.transform.parent = vocalist.transform.parent;
	newIcon2.transform.position.x += 200;
	newIcon2.transform.position.y -= 450;
	newIcon2.transform.position.x += spaceMulti;
	
	iconMove = true;
	spaceMulti += 150;
	vDir = -1;
	vocalDown = true;
	yield WaitForSeconds (2.3);
	iconMove = false;
	vDir = 1;
	vocalDown = true;
	yield WaitForSeconds (2);
	vocalDown = false;
	vocalist.transform.position.y = 800;
}