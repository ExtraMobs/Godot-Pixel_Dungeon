using System;
using Godot;

[GlobalClass]
public partial class PixelScene : Node2D
{
    // Tamanho virtual mínimo para a orientação Portrato
    public static float MinWidthP = 128;
    public static float MinHeightP = 224;

    // amanho virtual mínimo para a orientação Paisagem
    public static float MinWidthL = 224;
    public static float MinHeightL = 160;

    public static float DefaultZoom;
    public static float MinZoom;
    public static float MaxZoom;

    public static Camera UiCamera;

    // TODO BitmapText.Font

    public override void _Ready()
    {
        Camera.PixelScene = this;

        float minWidth;
        float minHeight;

        if (PixelDungeon.Landscape())
        {
            minWidth = MinWidthL;
            minHeight = MinHeightL;
        }
        else
        {
            minWidth = MinWidthP;
            minHeight = MinHeightP;
        }

        DefaultZoom = (float)Math.Ceiling(DisplayServer.ScreenGetDpi() * 2.5);

        Rect2 viewportRect = GetViewportRect();

        Vector2 windowRes = viewportRect.Size;
        while (
            (windowRes.X / DefaultZoom < minWidth || windowRes.Y / DefaultZoom < minHeight)
            && DefaultZoom > 1
        )
        {
            DefaultZoom--;
        }

        while (
            windowRes.X / (DefaultZoom + 1) >= minWidth
            && windowRes.Y / (DefaultZoom + 1) >= minHeight
        )
        {
            DefaultZoom++;
        }

        MinZoom = 1;
        MaxZoom = DefaultZoom * 2;

        // Não vale a pena fazer a classe 'PixelCamera' só pra isso
        Camera.Reset(
            new Camera()
            {
                Zoom = new Vector2(DefaultZoom, DefaultZoom),
                Position = new Vector2(
                    (int)(
                        viewportRect.Size.X
                        - Math.Ceiling(viewportRect.Size.X / DefaultZoom) * DefaultZoom
                    ) / 2,
                    (int)(
                        viewportRect.Size.Y
                        - Math.Ceiling(viewportRect.Size.Y / DefaultZoom) * DefaultZoom
                    ) / 2
                )
            }
        );

        float uiZoom = DefaultZoom;
        UiCamera = Camera.CreateFullscreen(uiZoom);
        Camera.Add(UiCamera);
    }
}
