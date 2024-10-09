using Godot;
using QuizGame.Helpers;
using System;

public partial class QuizScreen : Control
{
    public Button OptionA, OptionB, OptionC, OptionD, Next;
    public static RichTextLabel Question {get; private set;}
    private int _Current = 0;

    public override async void _Ready()
    {
        OptionA = GetNode<Button>("%OptionA");
        OptionB = GetNode<Button>("%OptionB");
        OptionC = GetNode<Button>("%OptionC");
        OptionD = GetNode<Button>("%OptionD");
        Next = GetNode<Button>("%Next");

        Question = GetNode<RichTextLabel>("%Question");

        OptionA.Pressed += OptionAPressed;
        OptionB.Pressed += OptionBPressed;
        OptionC.Pressed += OptionCPressed;
        OptionD.Pressed += OptionDPressed;
        Next.Pressed += NextPressed;
        QuestionsDeserialize QuestionFile = await QuizGame.Helpers.Json.LoadToFile<QuestionsDeserialize>("res://test.json",true);

        Quiz.ClearQuestions();
        foreach (var item in QuestionFile.Data)
        {
            Quiz.Questions.Add(item.Value);
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

    //Signals Handlers
    public void NextPressed ()
    {
        _Current++;
        UnlockButtons();
        Quiz.ShowQuestion(this,_Current);
        Next.Visible = false;
    }
    public void OptionAPressed ()
    {
        OptionPressed();
        Quiz.ShowResults(EAnswerField.A,_Current);
        LockButtons();
    }

    public void OptionBPressed ()
    {
        OptionPressed();
        Quiz.ShowResults(EAnswerField.B,_Current);
        LockButtons();
    }

    public void OptionCPressed ()
    {
        OptionPressed();
        Quiz.ShowResults(EAnswerField.C,_Current);
        LockButtons();
    }

    public void OptionDPressed ()
    {
        OptionPressed();
        Quiz.ShowResults(EAnswerField.D,_Current);
        LockButtons();
    }

    public void OptionPressed () //for every button press
    {
        if (!Answers.isLastQuestion(_Current))
        {
            Next.Visible = true;
            return;
        }
    }
}
