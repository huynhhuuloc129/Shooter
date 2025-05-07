using Godot;
using System;

public partial class Grenade : RigidBody2D
{
	public const int Speed = 750;
	
	public override void _Ready(){
			var sprite = GetNode<Sprite2D>("Explosion");
			sprite.Frame = 0; // force reset to start of animation
	}
	
	public void Explode(){
		GD.Print("explosion");
		GetNode<AnimationPlayer>("AnimationPlayer").Play("Explosion");
	}
}
