using Godot;
using System;

public class Player : Creature
{

	[Signal]
	public delegate void UpdatePlayerGuiHandler(Player player);
	
	public override void _Ready()
	{
		// Update GUI on stat changes
		health.statUpdated += UpdateGui;
	}
	
	public override void _Process(float delta)
	{
		ProcessMovement();
	}

	protected void ProcessMovement()
	{
		Move(InputHandler.MovementInput());
	}

	protected void UpdateGui(int newValue = -1)
	{
		EmitSignal(nameof(UpdatePlayerGuiHandler), this);
	}



}
