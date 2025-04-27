using Godot;
using System;


public partial class Level : Node2D
{
 	public void OnArea2DBodyEntered(Node2D body)
	{
		GD.Print("Player entered");
	}
	
	public void OnArea2DBodyExited(Node2D body){
		GD.Print("Player exited");
	}
}
