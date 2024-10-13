using Godot;
using System;

public partial class Curtain : CharacterBody2D
{
    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    public void Cycle (int wait_time)
    {
        Velocity=new Vector2(0,100);
        //wait time here
        Velocity=new Vector2(0,-100);
    }
}
