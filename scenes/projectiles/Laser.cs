using Godot;
using System;

public partial class Laser : Area2D
{
	[Export]
	public int speed = 1000; 
	public Vector2 direction = new Vector2(0, -1);
	
	public override void _Process(double delta) {
		Position += direction * Convert.ToInt32(speed * delta);
	}
}
