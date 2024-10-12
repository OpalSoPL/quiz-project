using Godot;
using System;

public partial class SummaryScreen : Control
{
    private RichTextLabel summaryLabel;
    private Button retryButton;

    public override void _Ready ()
    {
        summaryLabel = GetNode<RichTextLabel>("%SummaryLabel");
        retryButton = GetNode<Button>("%RetryButton");
        retryButton.Pressed += RetryButtonPressed;
    }

    public void ShowSummary ()
    {
        summaryLabel.Text = string.Format (summaryLabel.Text,Global.CorrectAnswers, Quiz.Questions.Count);
        Visible = !Visible;
    }

    public void RetryButtonPressed ()
    {
        //todo curtain drop
        GetTree().ChangeSceneToFile("res://src/scene/quiz_screen/quiz_screen.tscn");
    }
}
