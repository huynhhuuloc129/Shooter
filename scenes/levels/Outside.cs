using Godot;
using System;

public partial class Outside : Level
{
	public void OnGatePlayerEnteredGate(Node2D body){
		var tween = CreateTween();
		tween.TweenProperty(GetNode<Player>("Player"), "speed", 0, 0.45);
	}
}
