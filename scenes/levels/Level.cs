using Godot;
using System;
public partial class Level : Node2D
{
	PackedScene laserScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/laser.tscn");
	PackedScene grenadeScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/grenade.tscn");
	
	public void OnGatePlayerEnteredGate(Node2D body){
		GD.Print("player has entered gate");
		GD.Print(body);
	}
	
	public void OnPlayerOnGrenade(Vector2 position, Vector2 direction){
		var grenade = grenadeScene.Instantiate<Grenade>();
		grenade.Position = position;
		grenade.LinearVelocity = direction * Grenade.Speed;
		GetNode<Node2D>("Projectiles").AddChild(grenade);
	}
	
	public void OnPlayerOnLaser(Vector2 position, Vector2 direction){
		var laser = laserScene.Instantiate<Laser>();
		
		laser.Position = position;
		laser.direction = direction;
		laser.RotationDegrees = Mathf.RadToDeg(direction.Angle());
		GetNode<Node2D>("Projectiles").AddChild(laser);
	}
	public void OnHousePlayerEntered(){
		var tween = GetTree().CreateTween();
		var camera = GetNode<Camera2D>("Player/Camera2D");
		var vector = new Vector2(1, 1);
		tween.TweenProperty(camera, "zoom", vector, 1);
	}
	
	public void OnHousePlayerExited(){
		var tween = GetTree().CreateTween();
		var camera = GetNode<Camera2D>("Player/Camera2D");
		var vector = new Vector2((floatddddd)0.6, (floatddddd)0.6);
		tween.TweenProperty(camera, "zoom", vector, 1);
	}
	
}
