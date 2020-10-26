using Godot;
using System;

public class Creature : KinematicBody2D
{
	[Export]
	public String creatureName = "UNKNOWN";
	public Health health = new Health();
	private Vector2 worldPosition = Vector2.Zero;
	private TileMap map { 
		get {
			return GetParent().GetChild<TileMap>(0);
		}}

	protected void Move(Vector2 movement)
	{
		// Generate new position in world and check
		// if location is a valid location to move to.
		Vector2 new_pos = worldPosition + movement;
		if (map.IsValidMapPosition(new_pos))
		{
			Position = map.MapToWorld(worldPosition); // Update position based on tile location
			worldPosition = new_pos; // Save new location
		}
	}
}