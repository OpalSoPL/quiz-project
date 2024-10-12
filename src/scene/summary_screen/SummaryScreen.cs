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
        summaryLabel.Text = string.Format ("{0}/{1}",Quiz.Questions.Count,Global.CorrectAnswers);
    }

    public void RetryButtonPressed ()
    {
        //todo curtain drop
        GetTree().ChangeSceneToFile("res://src/scene/quiz_screen/quiz_screen.tscn");
    }
}
