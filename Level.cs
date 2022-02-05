using Godot;
using System;

public class Level : Node2D
{
    Camera2D camera;
    Player player;

    public override void _Ready()
    {
        camera = GetNode<Camera2D>("Player2/Camera2D");
        player = GetNode<Player>("Player2");

        camera.LookAt(player.Position);
    }
}
