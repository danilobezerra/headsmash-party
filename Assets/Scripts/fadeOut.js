var rend : SpriteRenderer;

function Start(){
	rend = transform.GetComponent("SpriteRenderer");
}

function FixedUpdate(){
	if (rend.color.a > 0){
		rend.color.a -= 0.01;
	}
}