using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public bool canLaser = true;
	public bool canGrenade = true;
	Timer timerLaser, timerGrenade;

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
			timerLaser.Start();
			GD.Print("Shoot laser");
			canLaser = false;
		}
		
//		Shoot grenade
		if (Input.IsActionPressed("secondary action") && canGrenade) {
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
