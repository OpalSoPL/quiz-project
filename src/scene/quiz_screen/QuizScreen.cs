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

    public void SetButtonsState (bool disable)
    {
        OptionA.Disabled = disable;
        OptionB.Disabled = disable;
        OptionC.Disabled = disable;
        OptionD.Disabled = disable;
    }

    public void ChangeVisibility(bool Visible)
    {
        OptionA.Visible = Visible;
        OptionB.Visible = Visible;
        OptionC.Visible = Visible;
        OptionD.Visible = Visible;
    }

    public void OptionHandler(EAnswerField Answer)
    {
        if (!Answers.isLastQuestion(_Current))
        {
            Next.Visible = true;
        }
        Quiz.ShowResults(Answer,_Current);
        SetButtonsState(true);
    }

    //Signals Handlers
    public void NextPressed ()
    {
        _Current++;
        SetButtonsState(false);
        Quiz.ShowQuestion(this,_Current);
        Next.Visible = false;
    }
    public void OptionAPressed () => OptionHandler(EAnswerField.A);
    public void OptionBPressed () => OptionHandler(EAnswerField.B);
    public void OptionCPressed () => OptionHandler(EAnswerField.C);
    public void OptionDPressed () => OptionHandler(EAnswerField.D);
}
