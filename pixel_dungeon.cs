using Godot;

public class PixelDungeon
{
	static internal bool Landscape()
	{
		Vector2I windowSize = DisplayServer.WindowGetSize();
		return windowSize.X > windowSize.Y;
	}

	bool ScaleUp() // todo
	{
		return false;
	}
}
