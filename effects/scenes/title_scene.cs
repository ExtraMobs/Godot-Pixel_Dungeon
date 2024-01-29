using Godot;

public partial class title_scene : Node2D
{
	public override void _Ready()
	{
		GD.Print(DisplayServer.ScreenGetDpi());
	}

	// public override void _Process(double delta)
	// {
	// }
}
