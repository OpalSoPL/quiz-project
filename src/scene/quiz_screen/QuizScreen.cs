using Godot;
using System;

public partial class QuizScreen : Control
{
    public Button OptionA, OptionB, OptionC, OptionD, Next;
    public static RichTextLabel Question {get; private set;}
    public SummaryScreen SummaryScreen;
    private int _current = Global.GoToQuestion is not -1 ? Global.GoToQuestion : 0 ;
    private Curtain _curtain;

    public override void _Ready()
    {
        OptionA = GetNode<Button>("%OptionA");
        OptionB = GetNode<Button>("%OptionB");
        OptionC = GetNode<Button>("%OptionC");
        OptionD = GetNode<Button>("%OptionD");
        Next = GetNode<Button>("%Next");

        Question = GetNode<RichTextLabel>("%Question");

        SummaryScreen = GetNode<SummaryScreen>("%Summary");

        _curtain = GetNode<Curtain>("%Curtain");

        OptionA.Pressed += OptionAPressed;
        OptionB.Pressed += OptionBPressed;
        OptionC.Pressed += OptionCPressed;
        OptionD.Pressed += OptionDPressed;
        Next.Pressed += NextPressed;

        Quiz.ShowQuestion(this,_current);
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

    public async void OptionHandler(EAnswerField Answer)
    {
        if (!Answers.isLastQuestion(_current))
        {
            Next.Visible = true;
        }
        else
        {
            SummaryScreen.ShowSummary();
        }

        SetButtonsState(true);

        _curtain.Cycle(1,500);
        await ToSignal(_curtain,nameof(_curtain.CurtainDown));

        Quiz.ShowResults(Answer,_current);
    }

    //Signals Handlers
    public void NextPressed ()
    {
        _current++;
        SetButtonsState(false);
        Quiz.ShowQuestion(this,_current);
        Next.Visible = false;
    }
    public void OptionAPressed () => OptionHandler(EAnswerField.A);
    public void OptionBPressed () => OptionHandler(EAnswerField.B);
    public void OptionCPressed () => OptionHandler(EAnswerField.C);
    public void OptionDPressed () => OptionHandler(EAnswerField.D);
}
