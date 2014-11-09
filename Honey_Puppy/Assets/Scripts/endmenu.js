var isMenu=false;

function OnMouseEnter(){
	//change text color
	renderer.material.color=Color.black;
}

function OnMouseExit(){
	//change text color
	renderer.material.color=Color.white;
}

function OnMouseUp(){
	Application.Quit();
}

function Update(){
	//quit game if escape key is pressed
	if (Input.GetKey(KeyCode.Escape)) { 
		Application.Quit();
	}
}