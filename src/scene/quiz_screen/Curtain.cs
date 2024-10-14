using Godot;
using System;

public partial class Curtain : CharacterBody2D
{
    private int _waitTime = 0;
    private bool doNotCycle = false;
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();

    }

    public void Cycle (int wait_time)
    {
        _waitTime = wait_time;
        Velocity=new Vector2(0,100);
        doNotCycle = false;
    }

    public async void FloorCollision(Node2D body)
    {
        if (doNotCycle)
        {
            return;
        }
        await ToSignal(GetTree().CreateTimer(_waitTime), SceneTreeTimer.SignalName.Timeout);
        Velocity=new Vector2(0,-100);
        doNotCycle = true;
    }
}
