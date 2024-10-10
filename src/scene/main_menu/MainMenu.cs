using Godot;
using System;

public partial class MainMenu : Control
{
    private Button PlayButton, SettingsButton;

    public override void _Ready()
    {
        PlayButton = GetNode<Button>("%PlayButton");
        PlayButton.Pressed += OnPlayPressed;

        var a = GetNode<Autoload>("/root/Autoload");
        a.Loaded += LateInit;
    }

    public void LateInit()
    {
        if (Global.GoToQuestion is not -1)
        {
            OnPlayPressed();
        }
    }

    public void OnPlayPressed()
    {
        GetTree().ChangeSceneToFile("res://src/scene/quiz_screen/quiz_screen.tscn");
    }
}
