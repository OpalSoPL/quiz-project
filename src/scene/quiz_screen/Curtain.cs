using Godot;
using System;

public partial class Curtain : CharacterBody2D
{
    [Signal]
    public delegate void CurtainDownEventHandler();

    private int _waitTime = 0;
    private float _speed = 500;
    private bool doNotCycle = false;
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();

    }

    public void Cycle (int wait_time,float speed)
    {
        _waitTime = wait_time;
        _speed = speed;

        Velocity=new Vector2(0,_speed);
        doNotCycle = false;
    }

    public async void FloorCollision(Node2D body)
    {
        if (doNotCycle)
        {
            return;
        }

        EmitSignal(nameof(CurtainDown));
        await ToSignal(GetTree().CreateTimer(_waitTime), SceneTreeTimer.SignalName.Timeout);
        Velocity=new Vector2(0,-_speed);
        doNotCycle = true;
    }
}
