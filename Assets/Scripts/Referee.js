#pragma strict

public var p1 : boolean = false;
public var changed : boolean = false;

function Awake () {
	DontDestroyOnLoad (transform.gameObject);
}

function FixedUpdate(){
	if (Application.loadedLevelName == "Decision" && !changed){
		Change();
		changed = true;
	}
}

function Player1 (){
	p1 = true;
}

function Player2 (){
	p1 = false;
}

function Change(){
	yield WaitForSeconds (2);
	if (p1){
		Application.LoadLevel ("Celebration_P1");
	}else{
		Application.LoadLevel ("Celebration_P2");
	}
	changed = false;
}