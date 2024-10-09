using System;
using System.Collections.Generic;
using Godot;

public static class Quiz
{
    public static List<Answer> Questions = new List<Answer>();

    public static bool ShowResults(EAnswerField answer, uint currentQuestion)
    {
        GD.Print(answer,currentQuestion);
        if (Answers.CheckAnswer(answer,currentQuestion))
        {
            QuizScreen.Question.Text = $"answer.{answer}";
            //todo trigger correct answer particles
            return true;
        }

        QuizScreen.Question.Text = $"answer.{Answers.getCorrectAnswer(currentQuestion)}";
        //todo trigger wrong answer particles
        return false;
    }

    public static void ClearQuestions ()
    {
        Questions = new List<Answer>();
    }
}