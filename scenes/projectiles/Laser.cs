using Godot;
using System;

public partial class Laser : Area2D
{
	[Export]
	public int speed = 1000; 
	public Vector2 direction;
	public override void _Ready(){

	}
	
	public override void _Process(double delta) {
		Position += direction * Convert.ToInt32(speed * delta);
		
	}
}
