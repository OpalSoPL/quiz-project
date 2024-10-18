using System;
using System.Collections.Generic;
using Godot;

public static class Quiz
{
    public static List<Answer> Questions = new List<Answer>();

    public static void ShowQuestion(this QuizScreen screen, int questionNumber)
    {
        screen.ChangeVisibility(false);
        Answer question = Questions[questionNumber];

        foreach(var item in question.Answers)
        {
            switch(item.Key)
            {
                case EAnswerField.A:
                    screen.OptionA.Text = item.Value;
                    screen.OptionA.Visible = true;
                    break;
                case EAnswerField.B:
                    screen.OptionB.Text = item.Value;
                    screen.OptionB.Visible = true;
                    break;
                case EAnswerField.C:
                    screen.OptionC.Text = item.Value;
                    screen.OptionC.Visible = true;
                    break;
                case EAnswerField.D:
                    screen.OptionD.Text = item.Value;
                    screen.OptionD.Visible = true;
                    break;
            }
        }

        QuizScreen.Question.Text = "[center]"+question.Description+"[/center]";
    }

    public static bool ShowResults(EAnswerField answer, int currentQuestion)
    {
        GD.Print(answer,currentQuestion);
        if (Answers.CheckAnswer(answer,currentQuestion))
        {
            QuizScreen.Question.Text = $"answer.{answer}";
            Global.CorrectAnswers++;
            //todo trigger correct answer particles
            return true;
        }

        QuizScreen.Question.Text = $"answer.{Answers.GetCorrectAnswer(currentQuestion)}";
        //todo trigger wrong answer particles
        return false;
    }

    public static void ClearQuestions ()
    {
        Questions = new List<Answer>();
    }
}