using Godot;
using System;

public partial class Logo : Sprite2D
{
	public Vector2 pos = new Vector2(0, 0);
	const int speed = 2;
	Vector2 testScale = new Vector2(1, 1);
	
	public override void _Ready(){
		pos = new Vector2(300, 200);	
		Position = pos;
		
		//var testRotation = 45;
		//RotationDegrees = testRotation;
		
		//testScale.X += 1;
		//testScale.Y += 1;
		//Scale = testScale;
	}
	
	public override void _Process(double delta){
		pos.X += speed;
		Position = pos;
		
		//testScale.X += 1;
		//testScale.Y += 1;
		//Scale = testScale;
	}
}
