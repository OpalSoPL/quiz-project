using Godot;
using System;

public partial class QuizScreen : Control
{
    private Button _OptionA, _OptionB, _OptionC, _OptionD;
    public static RichTextLabel Question {get; private set;}
    private uint _Current = 0;

    public override void _Ready()
    {
        _OptionA = GetNode<Button>("%OptionA");
        _OptionB = GetNode<Button>("%OptionB");
        _OptionC = GetNode<Button>("%OptionC");
        _OptionD = GetNode<Button>("%OptionD");

        Question = GetNode<RichTextLabel>("%Question");

        _OptionA.Pressed += OptionAPressed;
        _OptionB.Pressed += OptionBPressed;
        _OptionC.Pressed += OptionCPressed;
        _OptionD.Pressed += OptionDPressed;

        var quizInstance = new Quiz(); //temporal
    }

    public void LockButtons ()
    {
        _OptionA.Disabled = true;
        _OptionB.Disabled = true;
        _OptionC.Disabled = true;
        _OptionD.Disabled = true;
    }

    public void UnlockButtons ()
    {
        _OptionA.Disabled = false;
        _OptionB.Disabled = false;
        _OptionC.Disabled = false;
        _OptionD.Disabled = false;
    }


    public void OptionAPressed ()
    {
        Quiz.ShowResults(EAnswerField.A,_Current);
        LockButtons();
    }

    public void OptionBPressed ()
    {
        Quiz.ShowResults(EAnswerField.B,_Current);
        LockButtons();
    }

    public void OptionCPressed ()
    {
        Quiz.ShowResults(EAnswerField.C,_Current);
        LockButtons();
    }

        public void OptionDPressed ()
    {
        Quiz.ShowResults(EAnswerField.D,_Current);
        LockButtons();
    }
}
