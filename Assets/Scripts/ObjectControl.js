#pragma strict

public var speed : float = 10;
public var dirRight : boolean = false;


function FixedUpdate() {
	var dir : Vector3 = Vector3(1, 0, 0);
	if (!dirRight){
		dir.x = -1;
	}
	transform.Translate(dir * speed * Time.deltaTime);
}