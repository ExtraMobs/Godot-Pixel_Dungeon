using System;
using Godot;

public partial class pixel_scene : Node2D
{

	float MinWidthP = 128;
	float MinHeightP = 224;
	float MinWidthL = 224;
	float MinHeightL = 160;
	float DefaultZoom;
	float MinZoom;
	float MaxZoom;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		float minWidth;
		float minHeight;

		if (PixelDungeon.Landscape())
		{
			minWidth = MinWidthL;
			minHeight = MinHeightL;
		} else {
			minWidth = MinWidthP;
			minHeight = MinHeightP;
		}

		DefaultZoom = (float)Math.Ceiling(DisplayServer.ScreenGetDpi() * 2.5);

		Vector2 windowRes = GetViewportRect().Size;
		while((
			windowRes.X / DefaultZoom < minWidth ||
			windowRes.Y / DefaultZoom < minHeight
		) && DefaultZoom > 1)
		{
			DefaultZoom --;
		}

		while (
			windowRes.X / (DefaultZoom+1) >= minWidth &&
			windowRes.Y / (DefaultZoom+1) >= minHeight
		)
		{
			DefaultZoom ++;
		}

		MinZoom = 1;
		MaxZoom = DefaultZoom * 2;

		Camera2D camera = GetNode<Camera2D>("Camera");

		camera.Zoom = new Vector2(DefaultZoom, DefaultZoom);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
}
