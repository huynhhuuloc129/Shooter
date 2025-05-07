using Godot;
using System;

public partial class House : Area2D
{

	[Signal]	
	public delegate void PlayerEnteredEventHandler();
	
	[Signal]
	public delegate void PlayerExitedEventHandler();
	
	public void OnBodyEntered(Node2D body){
		EmitSignal(SignalName.PlayerEntered);
	}
	
	public void OnBodyExited(Node2D body){
		EmitSignal(SignalName.PlayerExited);
	}
}
