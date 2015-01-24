#pragma strict

public var spawning : boolean = false;
private var newEnemy : GameObject;
private var canSpawn : int = 1;
var player : int = 1;
var minSpawnPerSecond: float = 0.1;
var maxSpawnPerSecond: float = 0.2;
public var Enemy : GameObject[];
var playerStats : PlayerStats;


function Start() {
	playerStats = gameObject.GetComponent("PlayerStats");
}


function FixedUpdate(){
	canSpawn -= 1;
	if (spawning && canSpawn <= 0){
		var randObstacle : int = Random.Range(0,Enemy.length);
		var randPos : int = Random.Range(1,4);
		switch (randPos){
			case 1:
				randPos = -2.5;
				break;
			case 2:
				randPos = 0;
				break;
			case 3:
				randPos = 2.5;
				break;
		}
		newEnemy = Instantiate(Enemy[randObstacle], Vector3(0, randPos, 0), Quaternion.identity);
		if (player == 1){
			var speedMulti = playerStats.P1Speed / 10;
			var oc: ObjectControl = newEnemy.GetComponent("ObjectControl");
			oc.dirRight = false;
		}else {
			speedMulti = playerStats.P2Speed / 10;
			oc = newEnemy.GetComponent("ObjectControl");
			oc.dirRight = true;
		}
		oc = newEnemy.GetComponent("ObjectControl");
		oc.speed *= speedMulti;
		canSpawn = Random.Range((25 / (maxSpawnPerSecond*speedMulti)), (25 / (minSpawnPerSecond*speedMulti)));
	}
}