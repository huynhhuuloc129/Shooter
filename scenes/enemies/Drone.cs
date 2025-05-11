using Godot;
using System;

public partial class Drone : CharacterBody2D
{
	public bool isEnemey = true;
	
	 public override void _Ready()
	{

	}
	
	public override void _Process(double delta) {
//		Move right
		var direction = new Vector2(1, 0);
		Velocity = direction * 500;
		MoveAndSlide();
	}
	
	public void Hit(){
		GD.Print("Damage");
	}

}
