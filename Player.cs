using Godot;
using System;

public class Player : KinematicBody2D
{ 	
	[Export] float speed = 600;
	[Export] float gravityStrength = 10;

	float currentGravitySpeed;

	Vector2 direction;
	Vector2 currentSpeed;
	public override void _Ready()
	{
		currentSpeed = new Vector2(0,0);
	}

	public override void _Process(float delta)
	{
		GD.Print($"currentSpeed: {currentSpeed}");
	}

	public override void _PhysicsProcess(float delta)
	{
		ProcessInput();
		ProcessGravity(delta);
		ProcessVelocity(delta);
	}

	public void ProcessInput()
	{
		direction = Input.IsActionPressed("move_left")  ? new Vector2(-1, 0) : direction;
		direction = Input.IsActionPressed("move_right") ? new Vector2(1, 0)  : direction;
	}

	public void ProcessGravity(float delta)
	{
		if (IsOnFloor() == false)
			currentGravitySpeed += delta * gravityStrength;
		else
			currentGravitySpeed = 0;
	}

	public void ProcessVelocity(float delta)
	{
		currentSpeed = MoveAndSlide(
			linearVelocity: currentSpeed * speed + new Vector2(0, currentGravitySpeed) * delta
		);
	}
}
