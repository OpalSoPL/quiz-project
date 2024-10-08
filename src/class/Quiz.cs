using System;
using Godot;

public class Quiz //todo after testing, make this class static
{
    public static Question[] Questions = new Question[999];


    public Quiz ()
    {
        Question question = new()
        {
            correctAnswer = EAnswerField.C
        };
        Questions[0] = question;
    }

    public static bool ShowResults(EAnswerField answer, uint currentQuestion)
    {
        GD.Print(answer,currentQuestion);
        if (Answer.CheckAnswer(answer,currentQuestion))
        {
            QuizScreen.Question.Text = $"answer.{answer}";
            //todo trigger correct answer particles
            return true;
        }

        QuizScreen.Question.Text = $"answer.{Answer.getCorrectAnswer(currentQuestion)}";
        //todo trigger wrong answer particles
        return false;
    }
}