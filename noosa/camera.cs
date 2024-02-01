using Godot;
using System.Collections.Generic;

public partial class Camera : Camera2D
{
    public static Node2D PixelScene;
    protected static List<Camera2D> All = new();

    private static Camera _main;
    public static Camera Main
    {
        get{return _main;}
        set
        {
            foreach(Node child in PixelScene.GetChildren())
            {
                if (child.Name == "Camera")
                {
                    child.QueueFree();
                    break;
                }
            }
            PixelScene.AddChild(value);
            value.Name = "Camera";
            _main = value;
        }
    }

    public override void _Ready()
    {
        AnchorMode = AnchorModeEnum.FixedTopLeft;
    }

    public static Camera Reset()
    {
        return Reset(CreateFullscreen(1));
    }

    public static Camera Reset(Camera newCamera)
    {
        foreach (Camera camera in All)
        {
            camera.QueueFree();
        }
        All.Clear();
        
        return Main = Add(newCamera);
    }

    public static Camera Add(Camera camera)
    {
        All.Add(camera);
        return camera;
    }

    public static Camera CreateFullscreen(float zoom)
    {
        return new Camera()
        {
            Zoom = new Vector2(zoom, zoom)
        };
    }

}
