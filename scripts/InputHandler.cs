using Godot;

/// <summary>Class <c>InputHandler</c> holds static methods
/// for handling player input.</summary>
public static class InputHandler
{

    /// <summary>method <c>MovementInput</c> returns a Vector2 based on player input.</summary>
    public static Vector2 MovementInput()
	{
		Vector2 movement = new Vector2();
		if(Input.IsActionJustPressed("move_up"))
		{
			movement.y -= 1;
		}
		if(Input.IsActionJustPressed("move_down"))
		{
			movement.y += 1;
		}
		if(Input.IsActionJustPressed("move_right"))
		{
			movement.x += 1;
		}
		if(Input.IsActionJustPressed("move_left"))
		{
			movement.x -= 1;
		}
		return movement;
	}

    /// <summary>method <c>DebugKeyInput</c> returns bool when debug key is pressed in a debug build.</summary>
    public static bool DebugKeyInput()
    {
        if(OS.IsDebugBuild())
            return Input.IsActionJustPressed("debug_general");
        return false;
    }
}