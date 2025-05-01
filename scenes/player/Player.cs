using Godot;
using System;
public partial class Player : CharacterBody2D
{
	public bool canLaser = true;
	public bool canGrenade = true;
	Timer timerLaser, timerGrenade;

	[Signal]
	public delegate void OnLaserEventHandler(Vector2 position, Vector2 direction);
	
	[Signal]
	public delegate void OnGrenadeEventHandler(Vector2 position, Vector2 direction);

	public override void _Ready(){
		timerLaser = GetNode<Timer>("TimerLaser");
		timerGrenade = GetNode<Timer>("TimerGrenade");
	}
	
	public override void _Process(double delta){
		var direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * 500;
		MoveAndSlide();
		
//		rotate player
		LookAt(GetGlobalMousePosition());
 
//		Laser shooting input
		if (Input.IsActionPressed("primary action") && canLaser) {
//			randomly select a marker 2d for the laser start
			var laserMarkers = GetNode<Node2D>("LaserStartPositions").GetChildren();
			var selectedLaser = (Node2D)laserMarkers[GD.RandRange(0, laserMarkers.Count - 1)];
			timerLaser.Start();
			canLaser = false;

//			emit the position we selected
			var playerDirection = (GetGlobalMousePosition() - Position).Normalized();
			EmitSignal(SignalName.OnLaser, selectedLaser.GlobalPosition, playerDirection);
		}
		
//		Shoot grenade
		if (Input.IsActionPressed("secondary action") && canGrenade) {
			
			var laserMarkers = GetNode<Node2D>("LaserStartPositions").GetChildren();
			var selectedLaser = (Node2D)laserMarkers[GD.RandRange(0, laserMarkers.Count -1)];
			timerGrenade.Start();
			canGrenade = false;
			
			var playerDirection = (GetGlobalMousePosition() - Position).Normalized();
			EmitSignal(SignalName.OnGrenade, selectedLaser.GlobalPosition, playerDirection);
		}
	}
	
	public void OnTimerLaserTimeout(){
		canLaser = true;
	}
	public void OnTimerGrenadeTimeout(){
		canGrenade = true;
	}
	

}
