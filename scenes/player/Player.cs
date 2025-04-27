using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public bool canLaser = true;
	public bool canGrenade = true;
	Timer timerLaser, timerGrenade;

	[Signal]
	public delegate void OnLaserEventHandler(Vector2 position);
	
	[Signal]
	public delegate void OnGrenadeEventHandler();

	public override void _Ready(){
		timerLaser = GetNode<Timer>("TimerLaser");
		timerGrenade = GetNode<Timer>("TimerGrenade");
	}
	
	public override void _Process(double delta){
		var direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * 500;
		MoveAndSlide();
 
//		Laser shooting input
		if (Input.IsActionPressed("primary action") && canLaser) {
//			randomly select a marker 2d for the laser start
			var laserMarkers = GetNode<Node2D>("LaserStartPositions").GetChildren();
			var selectedLaser = (Node2D)laserMarkers[GD.RandRange(0, laserMarkers.Count - 1)];
			timerLaser.Start();
			canLaser = false;

//			emit the position we selected
			EmitSignal(SignalName.OnLaser, selectedLaser.GlobalPosition);
		}
		
//		Shoot grenade
		if (Input.IsActionPressed("secondary action") && canGrenade) {
			EmitSignal(SignalName.OnGrenade);
			timerGrenade.Start();
			GD.Print("Shoot grenade");
			canGrenade = false;
		}
	}
	
	public void OnTimerLaserTimeout(){
		canLaser = true;
	}
	public void OnTimerGrenadeTimeout(){
		canGrenade = true;
	}
	

}
