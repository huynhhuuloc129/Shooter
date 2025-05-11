using Godot;
using System;

public partial class Laser : Area2D
{
	[Export]
	public int speed = 1000; 
	public Vector2 direction;
	public override void _Ready(){
		var timer = GetNode<Timer>("SelfDestructTimer");
		timer.Start();
	}
	
	
	public override void _Process(double delta) {
		Position += direction * Convert.ToInt32(speed * delta);
		
	}
	public void OnSelfDestructTimerTimeout(){
		QueueFree();
	}
	
	public void OnBodyEntered(Node2D body){
		if (body.HasMethod("Hit")) {
			body.Call("Hit");
		}
		QueueFree();
	}
}
