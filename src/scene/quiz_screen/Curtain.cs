using Godot;
using System;

public partial class Curtain : TextureRect
{
    [Export]
    public float Movement_Time = 2f;
    [Signal]
    public delegate void MoveEndedEventHandler(int type);
    private readonly Vector2 _bottomPosition = new (0,-400);
    private readonly Vector2 _topPosition = new (0,-900);
    private Tween _tween;

    public void ResetTween()
    {
        _tween = GetTree().CreateTween();
    }

    public void Move(EMoveType type, double delay = 1d)
    {
        ResetTween();
        switch (type)
        {
            case EMoveType.Cycle:
                Cycle(delay);
                break;
            case EMoveType.Down:
                GoDown();
                break;
            case EMoveType.Up:
                GoUp();
                break;
        }
    }

    public void Cycle(double delay)
    {
        _tween.TweenProperty(this,"position",_bottomPosition,Movement_Time);

        _tween.TweenCallback(Callable.From(() => _moveEnd(EMoveType.Cycle)));

        _tween.Chain()
        .TweenProperty(this,"position",_topPosition,Movement_Time)
        .SetDelay(delay);
    }

    public void GoDown()
    {
        _tween.TweenProperty(this,"position",_bottomPosition,Movement_Time);
        _tween.TweenCallback(Callable.From(() => _moveEnd(EMoveType.Down)));
    }

    public void GoUp()
    {
        _tween.TweenProperty(this,"position",_topPosition,Movement_Time);
        _tween.TweenCallback(Callable.From(() => _moveEnd(EMoveType.Up)));
    }

    private void _moveEnd(EMoveType type)
    {
        EmitSignal(nameof(MoveEnded),(int)type);
    }
}
