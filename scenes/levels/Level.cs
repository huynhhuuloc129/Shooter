using Godot;
using System;


public partial class Level : Node2D
{
	string[] testArray = {"Test", "Hello", "stuff"};
	
	public override void _Ready(){
		GD.Print("Level node is ready");
		GetNode<Logo>("Logo").RotationDegrees = 90;
		
		foreach (string i in testArray) {
			GD.Print(i);
		}
		
	}
	
	public override void _Process(double delta){
		GetNode<Logo>("Logo").RotationDegrees += 1;
				
		var currentPosition = GetNode<Logo>("Logo").pos;

		if (currentPosition.X >= 1000) {
			GD.Print("Position exceed");
			currentPosition.X = 0;
		}
		
		GetNode<Logo>("Logo").pos = currentPosition;
	}
}
