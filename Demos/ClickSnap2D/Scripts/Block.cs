using Godot;
using System;

public partial class Block : Area2D
{
    private bool IsSelected = false;
    [Export] private Sprite2D sprite;
    private ShaderMaterial shaderMaterial;

    public override void _Ready()
    {
        if (sprite == null)
        {
            sprite = GetNode<Sprite2D>("Sprite2D");
        }

        if (sprite == null)
        {
            GetTree().Quit();
            return;
        }

        if (sprite.Material is ShaderMaterial spriteShader)
        {
            shaderMaterial = spriteShader;
        }

        if (shaderMaterial == null)
        {
            GetTree().Quit();
            return;
        }
    }

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        base._InputEvent(viewport, @event, shapeIdx);
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
            {
                IsSelected = (!IsSelected);
                GD.Print("Block: " + IsSelected);
            }
        }
    }

    public override void _Process(double delta)
    {
        shaderMaterial.SetShaderParameter("is_selected", IsSelected);
    }
}