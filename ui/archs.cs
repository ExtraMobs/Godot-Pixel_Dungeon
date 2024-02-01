using Godot;

public partial class archs : Node2D
{
	Sprite2D ArcsBg;
	Sprite2D ArcsFg;
	
	float OffsB;
	float OffsF;

	bool reversed = false;

	const float ScrollSpeed = 20;
	
	public override void _Ready()
	{
		ArcsBg = GetNode<Sprite2D>("Bg");
		ArcsFg = GetNode<Sprite2D>("Fg");
	}

	public override void _Process(double delta)
	{
		float shift = (float)(delta * ScrollSpeed);

		if (reversed)
		{
			shift = -shift;
		}

		// O projeto não deixou eu alterar o atributo
		// 'RegionRect.Position.Y' diretamente,
		// então tive que enviar um NOVO objeto de Rect2
		// com o Y atualizado.
		ArcsBg.RegionRect = new Rect2(
			new Vector2(
				ArcsBg.RegionRect.Position.X,
				ArcsFg.RegionRect.Position.Y +
				shift
			),
			ArcsBg.RegionRect.Size
		);
		ArcsFg.RegionRect = new Rect2(
			new Vector2(
				ArcsFg.RegionRect.Position.X,
				ArcsFg.RegionRect.Position.Y +
				shift * 2
			),
			ArcsBg.RegionRect.Size
		);

		OffsB = ArcsFg.RegionRect.Position.Y;
		OffsF = ArcsFg.RegionRect.Position.Y;
	}
}
