#pragma strict

public var inicialPos : Vector3;
public var finalPos : Vector3;

public var speed : float = 10;
public var dirRight : boolean = false;


function FixedUpdate(){
	var dir : Vector3 = Vector3(1,0,0);
	if (!dirRight){
		dir.x = -1;
	}
	transform.Translate(dir * speed * Time.deltaTime);
	
	if (gameObject.transform.position.x <= finalPos.x){
		gameObject.transform.position = inicialPos;
	}
}