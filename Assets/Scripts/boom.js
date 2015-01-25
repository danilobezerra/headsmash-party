var up : boolean = false;

function FixedUpdate(){
	if (!up){
		transform.position.y += 0.1;
		up = true;
	}else{
		transform.position.y -= 0.1;
		up = false;
	}
}