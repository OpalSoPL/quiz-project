using Godot;
using QuizGame.Helpers;
using System;

public partial class QuizScreen : Control
{
    public Button OptionA, OptionB, OptionC, OptionD;
    public static RichTextLabel Question {get; private set;}
    private int _Current = 0;

    public override async void _Ready()
    {
        OptionA = GetNode<Button>("%OptionA");
        OptionB = GetNode<Button>("%OptionB");
        OptionC = GetNode<Button>("%OptionC");
        OptionD = GetNode<Button>("%OptionD");

        Question = GetNode<RichTextLabel>("%Question");

        OptionA.Pressed += OptionAPressed;
        OptionB.Pressed += OptionBPressed;
        OptionC.Pressed += OptionCPressed;
        OptionD.Pressed += OptionDPressed;

        QuestionsDeserialize QuestionFile = await QuizGame.Helpers.Json.LoadToFile<QuestionsDeserialize>("res://test.json",true);

        Quiz.ClearQuestions();
        foreach (var item in QuestionFile.Data)
        {
            Quiz.Questions.Add(item.Value);
            GD.PushError("kurwa");
        }

        Quiz.ShowQuestion(this,_Current);
    }

    public void LockButtons ()
    {
        OptionA.Disabled = true;
        OptionB.Disabled = true;
        OptionC.Disabled = true;
        OptionD.Disabled = true;
    }

    public void UnlockButtons ()
    {
        OptionA.Disabled = false;
        OptionB.Disabled = false;
        OptionC.Disabled = false;
        OptionD.Disabled = false;
    }

    public void HideAll()
    {
        OptionA.Visible = false;
        OptionB.Visible = false;
        OptionC.Visible = false;
        OptionD.Visible = false;
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
