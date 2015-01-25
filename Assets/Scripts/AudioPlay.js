#pragma strict
public var seconds : float = 0;
public var loadLevelName : String;

function AudioPlay(){
	yield WaitForSeconds(seconds);
	Application.LoadLevel(loadLevelName);
}