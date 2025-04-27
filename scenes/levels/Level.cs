using Godot;
using System;


public partial class Level : Node2D
{
	PackedScene laserScene = ResourceLoader.Load<PackedScene>("res://scenes/projectiles/laser.tscn");
	public void OnGatePlayerEnteredGate(Node2D body){
		GD.Print("player has entered gate");
		GD.Print(body);
	}
	
	public void OnPlayerOnGrenade(){
		GD.Print("Grenade from level");
	}
	
	public void OnPlayerOnLaser(Vector2 position){
		var laser = laserScene.Instantiate<Node2D>();
		
		laser.Position = position;
//		3. I want to add a laser instance to a node2d
		GetNode<Node2D>("Projectiles").AddChild(laser);
	}
}
