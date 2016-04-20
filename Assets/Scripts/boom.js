var up : boolean = false;
var playing : boolean = false;

function FixedUpdate(){
	
	if(!playing){
		GetComponent.<AudioSource>().Play();
		playing = true;
	}
	if (!up){
		transform.position.y += 0.1;
		up = true;
	}else{
		transform.position.y -= 0.1;
		up = false;
	}
}