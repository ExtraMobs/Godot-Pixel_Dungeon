using Godot;

public partial class title_scene : pixel_scene
{
	public override void _Ready()
	{
		GD.Print(DisplayServer.ScreenGetDpi());
	}
}
