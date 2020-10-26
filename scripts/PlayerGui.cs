using Godot;
using System;

public class PlayerGui : CanvasLayer
{

	ProgressBar healtbar;
	public override void _Ready()
	{
		healtbar = GetNode<ProgressBar>("Control/HealthBar");
	}

	public void OnUpdatePlayerGui(Player player)
	{
		// Update healthbar
		if(healtbar != null)
		{
			healtbar.MaxValue = player.health.max;
			healtbar.MinValue = player.health.min;
			healtbar.Value = player.health.value;
		} else { GD.Print("WARNING: Healtbar not set!"); }
	}

}
